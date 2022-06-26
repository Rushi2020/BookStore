using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        string AddBookToWishlist(WishListModel wishListModel);
        string DeleteWishlist(int WishListId);
        List<WishListModel> GetWishListData(int id);
    }
}
