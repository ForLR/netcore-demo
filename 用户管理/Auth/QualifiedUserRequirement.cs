using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 用户管理.Auth
{
    public class QualifiedUserRequirement: IAuthorizationRequirement
    {
        public readonly string _roleName;
        public QualifiedUserRequirement(string roleName)
        {
            _roleName = roleName;
        }
    }
}
