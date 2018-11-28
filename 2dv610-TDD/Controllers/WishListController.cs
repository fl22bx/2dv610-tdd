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
        private UserManager<AuthUser> UserManager { get; set; }
        public WishListController(WishListFactory factory, UserManager<AuthUser> userManager, IAppContext context)
        {

            WishListFactory = factory;
            dbContext = context;
            UserManager = userManager;
        }

        [Route("/YourWishlist")]
        public IActionResult WishList(string msg = null)
        {
            ViewBag.msg = msg;
            WishListVieModel model = WishListFactory.PopulateWishListViewModel(UserManager.GetUserId(User));
            return View(model);

        }

        [Route("/SaveWishList")]
        public RedirectToActionResult Save(WishListVieModel model)
        {
          
            AddToContext(model.WantWishes.GetWishList, CategoriesEnum.Want);
            AddToContext(model.NeedWishes.GetWishList, CategoriesEnum.Need);
            AddToContext(model.WearWishes.GetWishList, CategoriesEnum.Wear);
            AddToContext(model.readWishes.GetWishList, CategoriesEnum.Read);

            int save = dbContext.SaveChanges();
            string msg = null;

            if (save > 0)
                msg = "Changes Saved";
            return RedirectToAction("WishList", new { msg });
        }

        private void AddToContext(List<Wish> model, CategoriesEnum cat)
        {
            foreach (Wish wish in model)
            {
                wish.AuthorId = UserManager.GetUserId(User);
                wish.Category = cat;
                dbContext.Wishes.Add(wish);
            }
        }

    }
}
