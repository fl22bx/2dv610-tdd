using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;

namespace XUnitTest
{
    class WishListViewModelTest
    {
        public WishListVieModel Sut { get; set; }
        public WishListViewModelTest()
        {
            Sut = new WishListVieModel();

            var wishListMock = Mock.Of<WishList>();
            Sut.NeedWishes = wishListMock;
        }

        public void NeedWishListNotNull()
        {
            Assert.NotNull(Sut.NeedWishes);
            
        }
    }
}
