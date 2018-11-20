using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace _2dv610_TDD.Controllers
{
    public class WishListController : Controller
{
    public WishListController()
    {
    }

    public IActionResult WishList()
    {
        return View();
    }
}
}
