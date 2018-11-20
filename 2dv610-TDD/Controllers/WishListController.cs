using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2dv610_TDD.Models.WishList;


namespace _2dv610_TDD.Controllers
{
    public class WishListController : Controller
{
    private WishListFactory WishListFactory { get; }
    public WishListController(WishListFactory factory)
    {
        WishListFactory = factory;
    }

    public IActionResult WishList()
    {
        return View();
    }
}
}
