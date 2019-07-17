using identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.Data
{
    public class AppDbcontext:IdentityDbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

    }
}
