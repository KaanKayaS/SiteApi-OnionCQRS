﻿using SiteApi.Application.Bases;
using SiteApi.Application.Features.Auth.Exceptions;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Features.Auth.Rules
{
    public class AuthRules: BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
