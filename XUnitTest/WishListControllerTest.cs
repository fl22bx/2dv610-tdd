using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using _2dv610_TDD.Controllers;
using _2dv610_TDD.Models.WishList;

namespace XUnitTest
{
 
    public class WishListControllerTest
    {
        public WishListController Sut { get; set; }
        public WishListControllerTest()
        {
            WishListFactory FactoryMock = new WishListFactory();
            Sut = new WishListController(FactoryMock);
        }

        [Fact]
        public void WishListShouldReturnView()
        {
           var Actual = Sut.WishList();
            Assert.IsType<ViewResult>(Actual);

        }
    }
}
