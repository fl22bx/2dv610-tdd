using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;

namespace XUnitTest
{
    public class WishListViewModelTest
    {
        public WishListVieModel Sut { get; set; }
        public WishListViewModelTest()
        {
            Sut = new WishListVieModel();

            var wishListMock = Mock.Of<WishList>();
            Sut.NeedWishes = wishListMock;
            Sut.WantWishes = wishListMock;
            Sut.readWishes = wishListMock;
            Sut.WearWishes = wishListMock;
        }

        [Fact]
        public void NeedWishListNotNull()
        {
            Assert.NotNull(Sut.NeedWishes);
            
        }

        [Fact]
        public void wantWishListNotNull()
        {
            Assert.NotNull(Sut.WantWishes);

        }


        [Fact]
        public void readtWishListNotNull()
        {
            Assert.NotNull(Sut.readWishes);

        }

        [Fact]
        public void WearWishListNotNull()
        {
            Assert.NotNull(Sut.WearWishes);

        }
    }
}
