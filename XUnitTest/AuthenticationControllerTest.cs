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
        public Mock<FakeUserManager> UserManagerMoq { get; set; }
        public Mock<FakeSignInManager> SignInManagerMoq { get; set; }

        public AuthenticationControllerTest()
        {
             UserManagerMoq = new Mock<FakeUserManager>();
             SignInManagerMoq = new Mock<FakeSignInManager>();
        }
        [Fact]
        public async void LogInShouldBeSuccesfull()
        {
            SignInManagerMoq.Setup(x => x.PasswordSignInAsync("ValidUserName", "ValidPassword", false, false))
                .ReturnsAsync(SignInResult.Success);

            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var result = await Sut.LogIn();
            RedirectToActionResult actual = (RedirectToActionResult)result;

            Assert.Equal("LoggedIn", actual.ActionName);
        }

        [Fact]
        public void ShouldReturnRegisterView()
        {
            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            var Actual = Sut.Register();
            Assert.IsType<ViewResult>(Actual);
        }

    }
}


// Reference To Code
// https://github.com/aspnet/Identity/issues/640
public class FakeUserManager : UserManager<AuthUser>
{
    public FakeUserManager()
        : base(new Mock<IUserStore<AuthUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<AuthUser>>().Object,
            new IUserValidator<AuthUser>[0],
            new IPasswordValidator<AuthUser>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<AuthUser>>>().Object)
    { }
}

// Reference To Code
// https://github.com/aspnet/Identity/issues/640
public class FakeSignInManager : SignInManager<AuthUser>
{
    public FakeSignInManager()
        : base(new FakeUserManager(),
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<AuthUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<AuthUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object)
    {}
}

