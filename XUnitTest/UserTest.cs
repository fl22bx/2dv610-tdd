using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;
using _2dv610_TDD.Models;

namespace XUnitTest
{
    public class UserTest
    {
        [Fact]
        public void UsernameWithLessThen3CharsShouldNotBeValidated()
        {
            List<ValidationResult> list = new List<ValidationResult>();
            User Sut = new User("a", "ValidPassword");
            Validator.TryValidateObject(Sut, new ValidationContext(Sut), list, true);
           var Actual = list.FirstOrDefault(x => x.MemberNames.ToList()[0] == "Username");
            Assert.NotNull(Actual);
        }

        [Fact]
        public void PasswordWithLessThen6ShouldNotBeValidated()
        {
            List<ValidationResult> list = new List<ValidationResult>();
            User Sut = new User("ValidUsername", "I");
            Validator.TryValidateObject(Sut, new ValidationContext(Sut), list, true);
            var Actual = list.FirstOrDefault(x => x.MemberNames.ToList()[0] == "Password");
            Assert.NotNull(Actual);
        }
    }

}
