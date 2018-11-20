using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace _2dv610_TDD.Models.WishList
{
    public class WishList
{
    public List<Wish> GetWishList { get;}
    public WishList()
    {
        GetWishList = new List<Wish>();
    }

    public void AddWish(Wish wish)
    {
            GetWishList.Add(wish);
    }

    public decimal GetPrice(CategoriesEnum Categori)
    {
        List<Wish> WishList = GetWishList;

        var SortedAfterCategorie =
            (from wish in WishList
                where wish.Category == Categori
                select wish.Price)
            .Sum();
        return SortedAfterCategorie;


    }
}
}
