using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using SiteApi.Application.Bases;
using SiteApi.Application.Features.Auth.Rules;
using SiteApi.Application.Interfaces.AutoMapper;
using SiteApi.Application.Interfaces.UnitOfWorks;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandHandler(UserManager<User> userManager,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
