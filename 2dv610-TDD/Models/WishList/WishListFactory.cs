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

        /// <summary>
        /// Creates WIshList from list of wishes
        /// </summary>
        /// <param name="wishes"></param>
        /// <returns></returns>
        public WishList NewWishList(List<Wish> wishes)
        {
            WishList Result = new WishList();
            foreach (Wish wish in wishes)
            {
                Result.AddWish(wish);
            }

            return Result;
        }

        /// <summary>
        /// Creates WishList ViewModel
        /// </summary>
        /// <param name="need"></param>
        /// <param name="want"></param>
        /// <param name="read"></param>
        /// <param name="wear"></param>
        /// <returns></returns>
        public WishListVieModel NewWishListViewModel(List<Wish> need, List<Wish> want, List<Wish> read, List<Wish> wear)
        {

            WishListVieModel Result = new WishListVieModel();

            Result.NeedWishes = NewWishList(need);
            Result.WantWishes = NewWishList(want);
            Result.readWishes = NewWishList(read);
            Result.WearWishes = NewWishList(wear);

           return Result;
        }

        /// <summary>
        /// Populates wishList with currentUsers wishes from Database
        /// </summary>
        /// <param name="CurrentUserId"></param>
        /// <returns></returns>
        public virtual WishListVieModel PopulateWishListViewModel(string CurrentUserId)
        {
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
