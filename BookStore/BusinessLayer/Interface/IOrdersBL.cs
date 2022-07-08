using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrdersBL
    {
        string AddOrders(OrdersModel ordersModel, int id);
        string DeleteOrders(int OrdersId);
        List<GetOrdersModel> GetAllOrders(int id);
    }
}
