using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using _2dv610_TDD.Models.Data;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;

namespace XUnitTest
{
    public class WishListFactoryTest
    {
        public class WishListFacatoryTest
        {
            public WishListFactory Sut { get; set; }

            public WishListFacatoryTest()
            {
               var MockUsermanager = new Mock<UserManagerStub>();
                MockUsermanager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("valid");

                Sut = new WishListFactory(DbContextMockSetub(), MockUsermanager.Object);
            }

            public IAppContext DbContextMockSetub()
            {

                var wishMockNeed = Mock.Of<Wish>();
                wishMockNeed.Price = 10;
                wishMockNeed.Category = CategoriesEnum.Need;
                wishMockNeed.AuthorId = "valid";

                var wishMockWant = Mock.Of<Wish>();
                wishMockWant.Price = 20;
                wishMockWant.Category = CategoriesEnum.Want;
                wishMockNeed.AuthorId = "valid";

                var wishMockWear = Mock.Of<Wish>();
                wishMockWear.Price = 30;
                wishMockWear.Category = CategoriesEnum.Wear;
                wishMockNeed.AuthorId = "valid";

                var wishMockRead = Mock.Of<Wish>();
                wishMockRead.Price = 40;
                wishMockRead.Category = CategoriesEnum.Read;
                wishMockNeed.AuthorId = "valid";

                var DbResultMock = new List<Wish>
                        {
                            wishMockNeed,
                            wishMockWant,
                            wishMockWear,
                            wishMockRead,

                            wishMockNeed,
                            wishMockWant,
                            wishMockWear,
                            wishMockRead,

                            wishMockNeed,
                            wishMockWant,
                            wishMockWear,
                            wishMockRead,

                            wishMockNeed,
                            wishMockWant,
                            wishMockWear,
                            wishMockRead,
            }.AsQueryable();

                var WishDbMock = new Mock<DbSet<Wish>>();

                WishDbMock.As<IQueryable<Wish>>().Setup(m => m.Provider).Returns(DbResultMock.Provider);
                WishDbMock.As<IQueryable<Wish>>().Setup(m => m.Expression).Returns(DbResultMock.Expression);
                WishDbMock.As<IQueryable<Wish>>().Setup(m => m.ElementType).Returns(DbResultMock.ElementType);
                WishDbMock.As<IQueryable<Wish>>().Setup(m => m.GetEnumerator()).Returns(DbResultMock.GetEnumerator());

                var MockRepository = Mock.Of<IAppContext>();
                MockRepository.Wishes = WishDbMock.Object;


                return MockRepository;
            }

            [Fact]
            public void noUserAuthorShouldNotReturnAnything()
            {
                var MockUsermanager = new Mock<UserManagerStub>();
                MockUsermanager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("UserId");
                Sut = new WishListFactory(DbContextMockSetub(), MockUsermanager.Object);
                WishListVieModel Actual = Sut.PopulateWishListViewModel();
                var test = Actual.WantWishes.GetWishList;
                Assert.Empty(Actual.WantWishes.GetWishList);
                Assert.Empty(Actual.readWishes.GetWishList);
                Assert.Empty(Actual.NeedWishes.GetWishList);
                Assert.Empty(Actual.WearWishes.GetWishList);

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

            [Fact]
            public void WishListViewModelTest()
            {
                List<Wish> ListWithWishes = new List<Wish>();
                var mockWish = Mock.Of<Wish>();
                ListWithWishes.Add(mockWish);
                ListWithWishes.Add(mockWish);
                ListWithWishes.Add(mockWish);

               var Actual = Sut.NewWishListViewModel(ListWithWishes, ListWithWishes, ListWithWishes, ListWithWishes);

                Assert.IsType<WishListVieModel>(Actual);
            }

            [Fact]
            public void ShouldReturnPopulatedWishViewModel()
            {
                WishListVieModel Actual = Sut.PopulateWishListViewModel();
                Assert.Equal(4, Actual.NeedWishes.GetWishList.Count);
                Assert.Equal(4, Actual.WantWishes.GetWishList.Count);
                Assert.Equal(4, Actual.WearWishes.GetWishList.Count);
                Assert.Equal(4, Actual.readWishes.GetWishList.Count);
            }


        }
    }
}
