using Microsoft.Extensions.DependencyInjection;
using SiteApi.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MediatR;
using SiteApi.Application.Beheviors;
using SiteApi.Application.Features.Products.Rules;
using SiteApi.Application.Features.Auth.Rules;

namespace SiteApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        { 
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient<ProductRules>();

            services.AddMediatR(cfg  => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            services.AddScoped<AuthRules>();
        }
    }
}
