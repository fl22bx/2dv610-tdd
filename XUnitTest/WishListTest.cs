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

        [Fact]
        public void GetTotalPriceOfWishesPerCategorie()
        {

            var wishMockNeed = Mock.Of<Wish>();
            wishMockNeed.Price = 10;
            wishMockNeed.Category = CategoriesEnum.Need;

            var wishMockWant = Mock.Of<Wish>();
            wishMockWant.Price = 20;
            wishMockWant.Category = CategoriesEnum.Want;

            var wishMockWear = Mock.Of<Wish>();
            wishMockWear.Price = 30;
            wishMockWear.Category = CategoriesEnum.Wear;

            var wishMockRead = Mock.Of<Wish>();
            wishMockRead.Price = 40;
            wishMockRead.Category = CategoriesEnum.Read;

            WishList Sut = new WishList();

            Sut.AddWish(wishMockNeed);
            Sut.AddWish(wishMockWant);
            Sut.AddWish(wishMockWear);
            Sut.AddWish(wishMockRead);

            Sut.AddWish(wishMockNeed);
            Sut.AddWish(wishMockWant);
            Sut.AddWish(wishMockWear);
            Sut.AddWish(wishMockRead);

            Sut.AddWish(wishMockNeed);
            Sut.AddWish(wishMockWant);
            Sut.AddWish(wishMockWear);
            Sut.AddWish(wishMockRead);
            

            decimal ExpectedWant = wishMockWant.Price * 3;

            decimal Acctual = Sut.GetPrice(CategoriesEnum.Want);

            Assert.Equal(ExpectedWant, Acctual);


        }
    }

}
