using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;


namespace _2dv610_TDD.Controllers
{
    public class WishListController : Controller
    {
        private WishListFactory WishListFactory { get; }
        public WishListController(WishListFactory factory)
        {
            WishListFactory = factory;
        }

        [Route("/YourWishlist")]
        public IActionResult WishList()
        {
            return View();

        }

    }
}
