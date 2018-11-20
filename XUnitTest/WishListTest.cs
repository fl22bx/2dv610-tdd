using System;
using System.Collections.Generic;
using System.Text;
using Moq;
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
            var wishMock = Mock.Of<Wish>();
            Sut.AddWish(wishMock);
            Sut.AddWish(wishMock);

            List<Wish> Actual = Sut.GetWishList;

            Assert.Equal(2 , Actual.Count);

        }
    }

}
