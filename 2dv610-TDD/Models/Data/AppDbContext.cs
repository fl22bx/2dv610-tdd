using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _2dv610_TDD.Models.Authentication;

namespace _2dv610_TDD.Models.Data
{
    public class AppDbContext : IdentityDbContext<AuthUser>
{
    public AppDbContext(DbContextOptions options) 
        : base(options)
    {
        
    }
}
}
