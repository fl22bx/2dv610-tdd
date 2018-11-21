using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.ViewModels
{
    public class WishListVieModel
{
    public WishList NeedWishes { get; set; }
    public WishList WantWishes { get; set; }

    public WishList readWishes { get; set; }   
}
}
