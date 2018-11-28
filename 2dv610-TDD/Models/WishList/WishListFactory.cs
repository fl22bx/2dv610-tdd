using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _2dv610_TDD.Models.Authentication;
using _2dv610_TDD.Models.Data;
using _2dv610_TDD.ViewModels;

namespace _2dv610_TDD.Models.WishList
{
    public class WishListFactory
    {
        private IAppContext Context { get; set; }
        


        public WishListFactory(IAppContext context)
        {
            Context = context;
        }
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

        public virtual WishListVieModel PopulateWishListViewModel(string CurrentUserId)
        {
            //todo: mpåste ha min 4 
            WishListVieModel Result = new WishListVieModel();

            List<Wish> need = EntityQuery(CategoriesEnum.Need, CurrentUserId);
            List<Wish> want = EntityQuery(CategoriesEnum.Want, CurrentUserId);
            List<Wish> wear = EntityQuery(CategoriesEnum.Wear, CurrentUserId);
            List<Wish> read = EntityQuery(CategoriesEnum.Read, CurrentUserId);

            Result.NeedWishes = NewWishList(need);
            Result.WantWishes = NewWishList(want);
            Result.WearWishes = NewWishList(wear);
            Result.readWishes = NewWishList(read);

            return Result;
        }

        private List<Wish> EntityQuery(CategoriesEnum cat, string id)
        {
            var QueryResult = (from wish in Context.Wishes
                where wish.Category == cat &&
                      wish.AuthorId == id
                               select wish);

            return QueryResult.ToList();

        }

    }
}
