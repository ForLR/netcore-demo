﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 用户管理.Auth
{
    public class EmailRequirement: IAuthorizationRequirement
    {
        public readonly string _email;
        public EmailRequirement(string email)
        {
            _email = email;
        }
    }
}
