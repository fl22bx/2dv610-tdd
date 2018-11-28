using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using _2dv610_TDD.Controllers;
using _2dv610_TDD.Models.Authentication;
using _2dv610_TDD.Models.Data;
using _2dv610_TDD.Models.WishList;
using _2dv610_TDD.ViewModels;

namespace XUnitTest
{
 
    public class WishListControllerTest
    {
        public WishListController Sut { get; set; }
        public WishListControllerTest()
        {
            var context = Mock.Of<IAppContext>();
            context.Wishes = Mock.Of<DbSet<Wish>>();

            Mock<UserManagerStub> UserManagerMoq = new Mock<UserManagerStub>();
            UserManagerMoq.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("UserId");
            WishListFactory FactoryMock = new WishListFactory(context, UserManagerMoq.Object);

            Mock.Get(context).Setup(x => x.SaveChanges()).Returns(1);

            Sut = new WishListController(FactoryMock, UserManagerMoq.Object, context);
        }

        [Fact]
        public void WishListShouldReturnView()
        {
           var Actual = Sut.WishList();
            Assert.IsType<ViewResult>(Actual);

        }

        [Fact]
        public void WishListViewBagTest()
        {
            string Expected = "Message To Send";
            var Actual = Sut.WishList(Expected);
            string viewbag = Sut.ViewBag.msg;

            Assert.Equal(Expected, viewbag);
        }

        [Fact]
        public void PostSaveWishListTest()
        { 
      
           
           var mockModel = Mock.Of<WishListVieModel>();
            mockModel.WearWishes = Mock.Of<WishList>();
            mockModel.NeedWishes = Mock.Of<WishList>();
            mockModel.WantWishes = Mock.Of<WishList>();
            mockModel.readWishes = Mock.Of<WishList>();

            mockModel.WearWishes.GetWishList = Setup();
            mockModel.NeedWishes.GetWishList = Setup();
            mockModel.WantWishes.GetWishList = Setup();
            mockModel.readWishes.GetWishList = Setup();

            var Result = Sut.Save(mockModel);

            RedirectToActionResult Actual = (RedirectToActionResult)Result;
            Assert.NotNull(Actual.RouteValues.Values);
            Assert.Equal("WishList", Actual.ActionName);

        }

        private List<Wish> Setup()
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

            return new List<Wish>
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
            };
        }
    }
}


