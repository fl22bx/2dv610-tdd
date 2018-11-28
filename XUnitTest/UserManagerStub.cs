using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using _2dv610_TDD.Models.Authentication;

namespace XUnitTest
{
    // Reference To Code
    // https://github.com/aspnet/Identity/issues/640
    public class UserManagerStub : UserManager<AuthUser>
    {
        public UserManagerStub()
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
}
