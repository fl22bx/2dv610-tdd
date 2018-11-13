using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;
using _2dv610_TDD.Models;

namespace XUnitTest
{
    public class UserTest
    {
        [Fact]
        public void UsernameWithLessThen3CharsShouldThrowError()
        {
            User Sut = new User("a", "ValidPassword");
            bool validate = Validator.TryValidateObject(Sut, new ValidationContext(Sut), null, true);
       
            Assert.False(validate);
        }
    }
}
