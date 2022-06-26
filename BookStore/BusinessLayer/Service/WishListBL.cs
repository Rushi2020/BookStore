using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL:IWishListBL
    {
        IWishListRL wishListRL;

        public WishListBL(IWishListRL wishlistRL)
        {
            this.wishListRL = wishlistRL;
        }

        public string AddBookToWishlist(WishListModel wishListModel)
        {
            try
            {
                return this.wishListRL.AddBookToWishlist(wishListModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string DeleteWishlist(int WishListId)
        {
            try
            {
                return this.wishListRL.DeleteWishlist(WishListId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<WishListModel> GetWishListData(int id)
        {
            try
            {
                return this.wishListRL.GetWishListData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
