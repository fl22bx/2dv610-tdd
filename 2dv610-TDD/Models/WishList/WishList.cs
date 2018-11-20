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
    public List<string> GetWishList { get; set; }
    public WishList()
    {
        GetWishList = new List<string>();
    }

    public void AddWish(string wish)
    {
            GetWishList.Add(wish);
    }
}
}
