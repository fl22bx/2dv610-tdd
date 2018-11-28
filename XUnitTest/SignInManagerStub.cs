using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using _2dv610_TDD.Models.Authentication;

namespace XUnitTest
{
    // Reference To Code
    // https://github.com/aspnet/Identity/issues/640
    public class SignInManagerStub : SignInManager<AuthUser>
    {
        public SignInManagerStub()
            : base(new UserManagerStub(), 
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<AuthUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<AuthUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object)
        { }
    }
}
