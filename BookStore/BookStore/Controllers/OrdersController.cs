using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersBL ordersBL;

        public OrdersController(IOrdersBL ordersBL)
        {
            this.ordersBL = ordersBL;
        }

        [HttpPost("AddOrder")]
        public ActionResult AddOrders(OrdersModel ordersModel)
        {
            try
            {
                string result = this.ordersBL.AddOrders(ordersModel);
                if (result.Equals("Success:- Ordered successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("DeleteOrder")]
        public ActionResult DeleteOrders(int OrdersId)
        {
            try
            {
                string result = this.ordersBL.DeleteOrders(OrdersId);
                if (result.Equals("Order deleted successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("GetAllOrders")]
        public ActionResult GetAllOrders(int id)
        {
            try
            {
                var result = this.ordersBL.GetAllOrders(id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "These are the all Orders : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
