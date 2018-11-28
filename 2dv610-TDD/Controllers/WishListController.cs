using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2dv610_TDD.Models.Authentication;
using _2dv610_TDD.Models.Data;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;


namespace _2dv610_TDD.Controllers
{
    public class WishListController : Controller
    {
        public IAppContext dbContext { get; set; }
        private WishListFactory WishListFactory { get; }
        public WishListController(WishListFactory factory, UserManager<AuthUser> userManager, IAppContext context)
        {
            WishListFactory = factory;
            dbContext = context;
        }

        [Route("/YourWishlist")]
        public IActionResult WishList(string msg = null)
        {
            return View();

        }

        [Route("/SaveWishList")]
        public RedirectToActionResult Save(WishListVieModel model)
        {
            foreach (Wish wish in model.WantWishes.GetWishList)
            {
                dbContext.Wishes.Add(wish);
            }

            foreach (Wish wish in model.NeedWishes.GetWishList)
            {
                dbContext.Wishes.Add(wish);
            }
            foreach (Wish wish in model.WearWishes.GetWishList)
            {
                dbContext.Wishes.Add(wish);
            }

            foreach (Wish wish in model.readWishes.GetWishList)
            {
                dbContext.Wishes.Add(wish);
            }

            int save = dbContext.SaveChanges();
            return RedirectToAction("WishList", new {msg = "Changes Saved"});
        }

    }
}
