using MediatR;
using SiteApi.Application.Interfaces.UnitOfWorks;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title, request.Description,request.BrandId,request.Price,request.Discount);

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
        }
    }
}
