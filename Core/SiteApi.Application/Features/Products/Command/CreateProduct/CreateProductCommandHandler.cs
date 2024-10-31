using MediatR;
using SiteApi.Application.Features.Products.Rules;
using SiteApi.Application.Interfaces.UnitOfWorks;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            this.unitOfWork = unitOfWork;
            this.productRules = productRules;
        }


        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

           

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);





            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if(await unitOfWork.SaveAsync() > 0)    //save async geriye int bir değer döndürcek döndürdüğü değerde örneğin
                                                    //1 product 3 kategori ekledik 4 değerini döndürür 0 dan büyükse işlem başarılı.
            {
                foreach (var categoryID in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryID,
                    });
                }

                await unitOfWork.SaveAsync();

            }

            return Unit.Value;
        }
    }
}
