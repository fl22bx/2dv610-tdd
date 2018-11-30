using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.Models.Data
{
    public interface IAppContext
    {
        /// <summary>
        /// Interface for Application Context
        /// </summary>
        DbSet<Wish> Wishes { get; set; }
        int SaveChanges();
        EntityEntry Remove(object entity);
    }
}
