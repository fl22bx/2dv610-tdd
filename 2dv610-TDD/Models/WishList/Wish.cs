using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    /// <summary>
    /// Db Key
    /// </summary>
        [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Description { get; set; }

    /// <summary>
    /// Short name for wish
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// CurrentUsers Id
    /// </summary>
    public string AuthorId { get; set; }


}
}
