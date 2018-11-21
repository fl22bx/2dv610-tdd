using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using _2dv610_TDD.Models.WishList;

namespace XUnitTest
{
    public class WishListFactoryTest
    {
        public class WishListFacatoryTest
        {
            public WishListFactory Sut { get; set; }

            public WishListFacatoryTest()
            {
                Sut = new WishListFactory();
            }

            [Fact]
            public void FactoryShouldProduceListOfWishes()
            {
                List<Wish> ListWithWishes = new List<Wish>();
                var mockWish = Mock.Of<Wish>();
                ListWithWishes.Add(mockWish);
                ListWithWishes.Add(mockWish);
                ListWithWishes.Add(mockWish);

                WishList actual = Sut.NewWishList(ListWithWishes);

                Assert.Equal(3, actual.GetWishList.Count);

            }
        }
    }
}
