using System;
using System.Collections.Generic;
using System.Linq;
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
            var test = new Mock<IAppContext>();
            Mock<UserManagerStub> UserManagerMoq = new Mock<UserManagerStub>();
            WishListFactory FactoryMock = new WishListFactory(test.Object);

            Sut = new WishListController(FactoryMock, UserManagerMoq.Object);
        }

        [Fact]
        public void WishListShouldReturnView()
        {
           var Actual = Sut.WishList();
            Assert.IsType<ViewResult>(Actual);

        }

        [Fact]
        public void PostSaveWishListTest()
        { 
           // todo: egen db qury class ej i constructor, i factory?

           var mockModel = Mock.Of<WishListVieModel>();
           var Result = Sut.Save(mockModel);


            RedirectToActionResult Actual = (RedirectToActionResult)Result;

            Assert.Equal("WishList", Actual.ActionName);

        }
    }
}


