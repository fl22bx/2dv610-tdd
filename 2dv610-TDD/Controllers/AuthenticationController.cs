using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using _2dv610_TDD.Models;
using _2dv610_TDD.Models.Authentication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2dv610_TDD.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<AuthUser> UserManager { get; set; }
        public SignInManager<AuthUser> SignInManager { get; set; }

        public AuthenticationController(UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserViewModel Model)
        {
            var result = await SignInManager.PasswordSignInAsync(Model.Username, Model.Password, false, false);

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

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel Model)
        {
            if (!ModelState.IsValid)
                return View();

            AuthUser newUser = new AuthUser();
            newUser.UserName = Model.Username;
            IdentityResult CreateNewUserResult = await UserManager.CreateAsync(newUser, Model.Password);

            if (!CreateNewUserResult.Succeeded)
                ModelState.AddModelError("", "Registration Failed. Please Try Again");

            await SignInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }
    }
}

