﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Heavy.Validata;

namespace Heavy.Models
{
    public class User: IdentityUser
    {
        public User()
        {
           
            Claims = new List<IdentityUserClaim<string>>();
            Logins = new List<IdentityUserLogin<string>>();
            Tokens = new List<IdentityUserToken<string>>();
            UserRoles = new List<IdentityUserRole<string>>();
        }

        [MaxLength(18)]
        public string IDCard { get; set; }
        [Required]
        [ValidataUrl(ErrorMessage = "Url不合规")]
        public string Url { get; set; }
        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
