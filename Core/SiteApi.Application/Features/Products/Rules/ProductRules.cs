using SiteApi.Application.Bases;
using SiteApi.Application.Features.Products.Exceptions;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x=> x.Title == requestTitle))  throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
