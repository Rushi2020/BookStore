using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public string AddBookToCart(CartModel cartModel , int id);
        string UpdateCart(int CartId, int OrderQuantity);
        List<GetCartModel> GetCartData(int Id);
        string DeleteCart(int CartId);

    }
}
