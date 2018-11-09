using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

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
