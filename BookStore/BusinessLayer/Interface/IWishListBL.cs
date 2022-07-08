using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        string AddBookToWishlist(WishListModel wishListModel, int id);
        string DeleteWishlist(int WishListId);
        List<WishListModel> GetWishListData(int id);
    }
}
