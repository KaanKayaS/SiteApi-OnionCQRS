﻿using MediatR;
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

namespace SiteApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager, RoleManager<Role> roleManager ,IMapper mapper , IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
           await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();  // aynı anda update giriş bu tarz şeylerde milisaniyelik fark için kullanılır.

          
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            
            if(result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),  // guid benzersiz bir kimlik oluşturmak için kullanıldı.
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),  
                    });

                await userManager.AddToRoleAsync(user, "user");
            }
            return Unit.Value;
        }
    }
}
