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
        private UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<IActionResult> LogIn()
        {
            // ToDo: HardCodedUser
            var result = await SignInManager.PasswordSignInAsync("ValidUserName", "ValidPassword", false, false);

            if (result.Succeeded)
                return RedirectToAction("LoggedIn");

            return RedirectToAction("LogInForm");


        }

        public IActionResult LoggedIn()
        {
            return StatusCode(200);
        }

        public IActionResult LogInForm()
        {
            return StatusCode(200);
        }
    }
}

