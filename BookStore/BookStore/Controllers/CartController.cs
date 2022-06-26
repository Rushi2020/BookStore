﻿using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost("Add Cart")]
        public ActionResult AddBookToCart(CartModel cartModel)
        {
            try
            {
                string result = this.cartBL.AddBookToCart(cartModel);
                if (result.Equals("Book added to cart successfully"))
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

        [HttpPut("Update Cart")]
        public ActionResult UpdateCart(int CartId, int OrderQuantity)
        {
            try
            {
                string result = this.cartBL.UpdateCart(CartId, OrderQuantity);
                if (result.Equals("Cart Updated successfully"))
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

        [HttpDelete("Delete Cart")]
        public ActionResult DeleteCart(int CartId)
        {
            try
            {
                string result = this.cartBL.DeleteCart(CartId);
                if (result.Equals("Cart deleted successfully"))
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

        [HttpGet]
        public ActionResult GetCartData(int Id)
        {
            try
            {
                var result = this.cartBL.GetCartData(Id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Books in the cart are : ", response = result });
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
