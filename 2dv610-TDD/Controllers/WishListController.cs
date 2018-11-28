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
            ViewBag.msg = msg;
            return View();

        }

        [Route("/SaveWishList")]
        public RedirectToActionResult Save(WishListVieModel model)
        {
          
            AddToContext(model.WantWishes.GetWishList);
            AddToContext(model.NeedWishes.GetWishList);
            AddToContext(model.WearWishes.GetWishList);
            AddToContext(model.readWishes.GetWishList);

            int save = dbContext.SaveChanges();
            string msg = null;

            if (save > 0)
                msg = "Changes Saved";
            return RedirectToAction("WishList", new { msg });
        }

        private void AddToContext(List<Wish> model)
        {
            foreach (Wish wish in model)
            {
                dbContext.Wishes.Add(wish);
            }
        }

    }
}
