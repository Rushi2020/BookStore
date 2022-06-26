using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        public string AddBookToWishlist(WishListModel wishListModel);
        string DeleteWishlist(int WishListId);
        List<WishListModel> GetWishListData(int id);
    }
}
