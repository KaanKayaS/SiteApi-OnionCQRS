using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteApi.Infrastructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Mapper
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
           
        }
    }
}
