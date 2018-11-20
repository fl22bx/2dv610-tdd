using System;
using System.Collections.Generic;
using System.Text;
using _2dv610_TDD.Controllers;

namespace XUnitTest
{
    class WishListControllerTest
    {
        public WishListController Sut { get; set; }
        public WishListControllerTest()
        {
            Sut = new WishListController();
        }

        public void WishListShouldReturnView()
        {
           var Actual = Sut.WishList();

        }
    }
}
