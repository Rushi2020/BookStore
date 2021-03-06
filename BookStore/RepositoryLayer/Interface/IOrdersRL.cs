using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrdersRL
    {
        string AddOrders(OrdersModel ordersModel, int id);
        string DeleteOrders(int OrdersId);
        List<GetOrdersModel> GetAllOrders(int id);
    }
}
