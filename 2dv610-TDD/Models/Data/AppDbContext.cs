using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _2dv610_TDD.Models.Authentication;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.Models.Data
{
    public class AppDbContext : IdentityDbContext<AuthUser> , IAppContext
    {
        /// <summary>
        /// Ef Core Application Context
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions options) 
            : base(options)
        { }

        /// <summary>
        /// Wishes from Database 
        /// </summary>
        public DbSet<Wish> Wishes { get; set; }
    
    }
}
