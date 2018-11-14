using System;
using System.Collections.Generic;
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
        public void LogInShouldBeSuccesfull()
        {
            AuthenticationController Sut = new AuthenticationController(UserManagerMoq.Object, SignInManagerMoq.Object);
            RedirectToRouteResult actual = (RedirectToRouteResult)Sut.LogIn();
            Assert.Equal("LoggedIn",actual.RouteValues["action"]);
        }
    }
}


// Reference To Code
// https://github.com/aspnet/Identity/issues/640
public class FakeUserManager : UserManager<User>
{
    public FakeUserManager()
        : base(new Mock<IUserStore<User>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<User>>().Object,
            new IUserValidator<User>[0],
            new IPasswordValidator<User>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<User>>>().Object)
    { }
}

// Reference To Code
// https://github.com/aspnet/Identity/issues/640
public class FakeSignInManager : SignInManager<User>
{
    public FakeSignInManager()
        : base(new FakeUserManager(),
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<User>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<User>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object)
    {


    }

    // MyCode
    public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        Mock<SignInResult> SignInResultMock = new Mock<SignInResult>();
        SignInResultMock.Setup(moq => moq.Succeeded).Returns(true);

        return SignInResultMock.Object;
    }
}
