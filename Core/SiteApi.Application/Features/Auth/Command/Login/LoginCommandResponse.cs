using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Auth.Command.Login
{
    internal class LoginCommandResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
