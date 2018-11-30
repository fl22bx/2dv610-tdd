using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using _2dv610_TDD.Models;
using _2dv610_TDD.Models.Authentication;


namespace _2dv610_TDD.Controllers
{
    /// <summary>
    /// Handles All Authenticaation and registration calls from Client
    /// Uses EntityFramework Core Identity API
    /// </summary>
    public class AuthenticationController : Controller
    {
        private UserManager<AuthUser> UserManager { get; set; }
        public SignInManager<AuthUser> SignInManager { get; set; }

        public AuthenticationController(UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        /// <summary>
        /// Renders the Login Form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Tries to validate LogIn coming in v
        /// 
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Renders Register Form
        /// </summary>
        /// <returns></returns>
        public ViewResult Register()
        {
            return View();
        }

        /// <summary>
        /// Handel register information via post request
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel Model)
        {
            if (!ModelState.IsValid)
                return View();

            AuthUser newUser = new AuthUser();
            newUser.UserName = Model.Username;
            IdentityResult CreateNewUserResult = await UserManager.CreateAsync(newUser, Model.Password);

            if (!CreateNewUserResult.Succeeded)
            {
                ModelState.AddModelError("", "Registration Failed. Please Try Again");
                return View();
            }
              

            if (CreateNewUserResult.Succeeded)
                await SignInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Signs out user and redirects to login page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}

