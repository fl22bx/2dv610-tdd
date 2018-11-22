using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.Models.Data
{
    public interface IAppContext
    {
        DbSet<Wish> Wishes { get; set; }
    }
}
