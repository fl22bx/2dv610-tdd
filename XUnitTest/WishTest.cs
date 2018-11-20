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

        [Fact]
        public void ShouldReturnPriceOfWish()
        {

            Sut.Price = 29;
            Assert.Equal(29, Sut.Price);
            Assert.IsType<Decimal>(Sut.Price);
        }

        [Fact]
        public void PriceCantBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Sut.Price = -1);
        }

        [Fact]
        public void DescriptionShouldBeSet()
        {

            Sut.Description = "Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem";
            Assert.NotNull(Sut.Description);
        }      

        [Fact]
        public void WishNameShouldNutBeNull()
        {

            Sut.Name = "Radio";
            Assert.NotNull(Sut.Name);
        }

        [Fact]
        public void AuthorId()
        {
            Sut.AuthorId = "d883f4d2 - 3986 - 4840 - b9cb - ff4db8d67d66";
            Assert.NotNull(Sut.AuthorId);
        }
    }
}
