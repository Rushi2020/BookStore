using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        public string AddBookToWishlist(WishListModel wishListModel, int id);
        string DeleteWishlist(int WishListId);
        List<WishListModel> GetWishListData(int id);
    }
}
