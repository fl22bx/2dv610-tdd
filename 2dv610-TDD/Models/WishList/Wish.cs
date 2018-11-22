using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2dv610_TDD.Models.WishList
{
    public class Wish
{
    public CategoriesEnum Category { get; set; }

    private decimal price;
    public decimal Price
    {
        get =>  price;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            price = value;
        }
    }

    public string Description { get; set; }

    public string Name { get; set; }

    public string AuthorId { get; set; }


}
}
