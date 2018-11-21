using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2dv610_TDD.ViewModels;

namespace _2dv610_TDD.Models.WishList
{
    public class WishListFactory
    {
        public WishList NewWishList(List<Wish> wishes)
        {
            WishList Result = new WishList();
            foreach (Wish wish in wishes)
            {
                Result.AddWish(wish);
            }

            return Result;
        }

        public WishListVieModel NewWishListViewModel(List<Wish> need, List<Wish> want, List<Wish> read, List<Wish> wear)
        {

            WishListVieModel Result = new WishListVieModel();

            Result.NeedWishes = NewWishList(need);
            Result.WantWishes = NewWishList(want);
            Result.readWishes = NewWishList(read);
            Result.WearWishes = NewWishList(wear);

            return Result;
        }
    }
}
