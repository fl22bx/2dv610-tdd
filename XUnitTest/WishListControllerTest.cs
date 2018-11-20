using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using _2dv610_TDD.Controllers;

namespace XUnitTest
{
 
    public class WishListControllerTest
    {
        public WishListController Sut { get; set; }
        public WishListControllerTest()
        {
            Sut = new WishListController();
        }

        [Fact]
        public void WishListShouldReturnView()
        {
           var Actual = Sut.WishList();
            Assert.IsType<ViewResult>(Actual);

        }
    }
}
