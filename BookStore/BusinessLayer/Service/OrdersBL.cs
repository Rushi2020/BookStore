using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrdersBL:IOrdersBL
    {
        IOrdersRL ordersRL;

        public OrdersBL(IOrdersRL ordersRL)
        {
            this.ordersRL = ordersRL;
        }

        public string AddOrders(OrdersModel ordersModel, int id)
        {

            try
            {
                return this.ordersRL.AddOrders(ordersModel,id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteOrders(int OrdersId)
        {
            try
            {
                return this.ordersRL.DeleteOrders(OrdersId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<GetOrdersModel> GetAllOrders(int id)
        {

            try
            {
                return this.ordersRL.GetAllOrders(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
