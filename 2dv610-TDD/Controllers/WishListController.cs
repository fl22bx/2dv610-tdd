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
        public AppDbContext dbContext { get; set; }
        private WishListFactory WishListFactory { get; }
        public WishListController(WishListFactory factory, UserManager<AuthUser> userManager, IAppContext context)
        {
            WishListFactory = factory;
        }

        [Route("/YourWishlist")]
        public IActionResult WishList()
        {
            return View();

        }

        public IActionResult Save(WishListVieModel model)
        {
            return StatusCode(500);
        }

    }
}
