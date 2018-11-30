using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Moq;
using _2dv610_TDD.Controllers;
using _2dv610_TDD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;
using _2dv610_TDD.Models.Authentication;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace XUnitTest
{
    public class AuthenticationControllerTest
    {
        public Mock<UserManagerStub> UserManagerMoq { get; set; }
        public Mock<SignInManagerStub> SignInManagerMoq { get; set; }

        public AuthenticationControllerTest()
        {
             UserManagerMoq = new Mock<UserManagerStub>();
             SignInManagerMoq = new Mock<SignInManagerStub>();
        }
        [Fact]
        public async void LogInShouldBeSuccesfull()
        {
            SignInManagerMoq.Setup(x => x.PasswordSignInAsync("ValidUserName", "ValidPassword", false, false))
                .ReturnsAsync(SignInResult.Success);
            var MockViewModel = Mock.Of<UserViewModel>();
            MockViewModel.Password = "ValidPassword";
            MockViewModel.Username = "ValidUserName";
            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var result = await Sut.LogIn(MockViewModel);
            RedirectToActionResult actual = (RedirectToActionResult)result;

            Assert.Equal("LoggedIn", actual.ActionName);
        }

        [Fact]
        public void LogInViewShouldBeReturned()
        {
            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var Actual =Sut.LogIn();
            Assert.IsType<ViewResult>(Actual);
        }

        [Fact]
        public void ShouldReturnRegisterView()
        {
            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var Actual = Sut.Register();
            Assert.IsType<ViewResult>(Actual);
        }

        [Fact]
        public async void RegisterWithInValidCredentialsShouldReturnViewResult()
        {
            var Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);

            var MockViewModel = new Mock<UserViewModel>();
            Sut.ModelState.AddModelError("Password", "Error");
            var Result = await Sut.Register(MockViewModel.Object);
            ViewResult Actual = (ViewResult) Result;
            Assert.NotNull(Actual.ViewData.ModelState);
            Assert.Equal("Register", Actual.ViewName);

            
        }

        [Fact]
        public void RegisterWithValidCredentialsShouldReturnRedirectResult()
        {
            var ModelMock = Mock.Of<UserViewModel>(x =>
                x.Username == "ValidUsername" &&
                x.Password == "ValidPassword");

            UserManagerMoq.Setup(x => x.CreateAsync(It.IsAny<AuthUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            var Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var Result = Sut.Register(ModelMock);
            Assert.IsType<RedirectToActionResult>(Result.Result);
        }

        [Fact]
        public async void SignOutShouldReturnLogInView()
        {
            var sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            Task<IActionResult> Result =  sut.SignOut();
            Assert.IsType<RedirectToActionResult>(Result.Result);
            RedirectToActionResult Actual = (RedirectToActionResult) Result.Result;
            Assert.Equal("LogIn", Actual.ActionName);
            
        }

    }
}




