using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtAuthSample
{
    public class MyTokenValidate : ISecurityTokenValidator
    {
        public bool CanValidateToken =>  true;

        public int MaximumTokenSizeInBytes { get ; set ; }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            if (securityToken == "abcdefg")
            {
                identity.AddClaim(new Claim("name", "lurui"));
                identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin"));
                identity.AddClaim(new Claim("SuperAdmin", "true"));
            }
          
            var p = new ClaimsPrincipal(identity);
            return p;
        }
    }
}
