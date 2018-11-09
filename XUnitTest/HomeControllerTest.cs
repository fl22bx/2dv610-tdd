using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using _2dv610_TDD.Controllers;

namespace XUnitTest
{
    public class HomeControllerTest
    {
        private HomeController Sut { get; set; }
        public HomeControllerTest()
        {
            Sut = new HomeController();
        }
        [Fact]
        public void IndexShouldBeViewResult()
        {

            var actual = Sut.Index();

            Assert.IsType<ViewResult>(actual);
        }
    }
}
