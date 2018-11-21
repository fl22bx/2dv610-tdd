using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.ViewModels
{
    public class WishListVieModel
{
    public WishListVieModel()
    {
        NeedWishes = new WishList()
        {
            GetWishList = new List<Wish>()
            {
                new Wish() { Category = CategoriesEnum.Need },
                new Wish() { Category = CategoriesEnum.Need },
                new Wish() { Category = CategoriesEnum.Need },
                new Wish() { Category = CategoriesEnum.Need },
                new Wish() { Category = CategoriesEnum.Need }
            }
        };

        WantWishes = new WishList()
        {
            GetWishList = new List<Wish>()
            {
                new Wish() { Category = CategoriesEnum.Want },
                new Wish() { Category = CategoriesEnum.Want },
                new Wish() { Category = CategoriesEnum.Want },
                new Wish() { Category = CategoriesEnum.Want },
                new Wish() { Category = CategoriesEnum.Want }
            }
        };

        WearWishes = new WishList()
        {
            GetWishList = new List<Wish>()
            {
                new Wish() { Category = CategoriesEnum.Wear },
                new Wish() { Category = CategoriesEnum.Wear },
                new Wish() { Category = CategoriesEnum.Wear },
                new Wish() { Category = CategoriesEnum.Wear },
                new Wish() { Category = CategoriesEnum.Wear }
            }
        };


        readWishes = new WishList()
        {
            GetWishList = new List<Wish>()
            {
                new Wish() { Category = CategoriesEnum.Read },
                new Wish() { Category = CategoriesEnum.Read },
                new Wish() { Category = CategoriesEnum.Read },
                new Wish() { Category = CategoriesEnum.Read },
                new Wish() { Category = CategoriesEnum.Read }
            }
        };
        }
        
        public WishList NeedWishes { get; set; }
        public WishList WantWishes { get; set; }

         public WishList readWishes { get; set; }
          public WishList WearWishes { get; set; }
}
}
