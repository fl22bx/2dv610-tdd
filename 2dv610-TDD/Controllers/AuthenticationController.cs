using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using _2dv610_TDD.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2dv610_TDD.Controllers
{
    public class AuthenticationController : Controller
{
    public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
    {

    }
    public IActionResult LogIn()
    {
        return View();
    }

    }
}
