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
           List<ValidationResult> list  = GetValidationResult("I", "ValidPassword");
           var actual = list.FirstOrDefault(x => x.MemberNames.ToList()[0] == "Username");
           Assert.NotNull(actual);
        }

        [Fact]
        public void PasswordWithLessThen6ShouldNotBeValidated()
        {
            List<ValidationResult> list = GetValidationResult("ValidUsername", "I");
            var actual = list.FirstOrDefault(x => x.MemberNames.ToList()[0] == "Password");
            Assert.NotNull(actual);
        }

        private List<ValidationResult> GetValidationResult(string Username, string Password)
        {
            List<ValidationResult> list = new List<ValidationResult>();
            UserViewModel Sut = new UserViewModel();
            Sut.Password = Password;
            Sut.Username = Username;
            Validator.TryValidateObject(Sut, new ValidationContext(Sut), list, true);
            return list;
        }

    }

}
