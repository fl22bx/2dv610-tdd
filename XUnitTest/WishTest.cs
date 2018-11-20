using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using _2dv610_TDD.Models.WishList;

namespace XUnitTest
{
    public class WishTest
    {
        public Wish Sut { get; set; }
        public WishTest()
        {
            Sut = new Wish();
        }

        [Fact]
        public void CategoryShouldBeFromCategoryEnum()
        {
            Sut.Category = CategoriesEnum.Need;
            Assert.Equal(CategoriesEnum.Need, Sut.Category);

            Sut.Category = CategoriesEnum.Want;
            Assert.Equal(CategoriesEnum.Want, Sut.Category);

            Sut.Category = CategoriesEnum.Wear;
            Assert.Equal(CategoriesEnum.Wear, Sut.Category);

            Sut.Category = CategoriesEnum.Read;
            Assert.Equal(CategoriesEnum.Read, Sut.Category);
        }

    }
}
