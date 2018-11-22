using System;
using System.Collections.Generic;
using System.Linq;
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
                Sut = new WishListFactory(DbContextMockSetub());
            }

            public IAppContext DbContextMockSetub()
            {
                var need = Mock.Of<Wish>();
                need.Price = 33;
                need.Category = CategoriesEnum.Need;
                need.Name = "Something i need";

                var want = Mock.Of<Wish>();
                need.Price = 33;
                need.Category = CategoriesEnum.Want;
                need.Name = "Something i want";

                var read = Mock.Of<Wish>();
                need.Price = 150;
                need.Category = CategoriesEnum.Read;
                need.Name = "Something i need";

                var wear = Mock.Of<Wish>();
                need.Price = 23;
                need.Category = CategoriesEnum.Wear;
                need.Name = "Something i wear";

                var DbResultMock = new List<Wish>
            {
                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,

                need,
                want,
                read,
                wear,
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
                Assert.Equal(8, Actual.NeedWishes.GetWishList.Count);
                Assert.Equal(8, Actual.WantWishes.GetWishList.Count);
                Assert.Equal(8, Actual.WearWishes.GetWishList.Count);
                Assert.Equal(8, Actual.readWishes.GetWishList.Count);
            }


        }
    }
}
