using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using _2dv610_TDD.Models.WishList;

namespace XUnitTest
{
    public class WishListTest
    {
        [Fact]
        public void ShouldReturnListWithWishes()
        {
            WishList Sut  = new WishList();

            Sut.AddWish("Wish1");
            Sut.AddWish("Wish2");

            List<string> Actual = Sut.GetWishList;

            Assert.Equal(2 , Actual.Count);

        }
    }

}
