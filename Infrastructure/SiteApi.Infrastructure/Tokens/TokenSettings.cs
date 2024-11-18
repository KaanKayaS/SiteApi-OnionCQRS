using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Infrastructure.Tokens
{
    public class TokenSettings
    {

        public string Auidience { get; set; }

        public string Issuer { get; set; }

        public string Secret { get; set; }

        public int TokenValidityInMunitiues { get; set; }

    }
}
