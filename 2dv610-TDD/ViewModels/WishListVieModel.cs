using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD.ViewModels
{
    public class WishListVieModel
{
    public WishListVieModel()
    {
        NeedWishes = new WishList();

        WantWishes = new WishList();

        WearWishes = new WishList();


        readWishes = new WishList();
        }
        
        public WishList NeedWishes { get; set; }
        public WishList WantWishes { get; set; }

         public WishList readWishes { get; set; }
          public WishList WearWishes { get; set; }
}
}
