using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost("AddAddress")]
        public ActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                string result = this.addressBL.AddAddress(addressModel, id);
                if (result.Equals("Success:- Address added successfully"))
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
        [HttpPut("UpdateAddress")]
        public ActionResult UpdateAddress(AddressModel addressModel)
        {
            try
            {
                string result = this.addressBL.UpdateAddress(addressModel);
                if (result.Equals("Success:- Address Updated successfully"))
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

        [HttpDelete("DeleteAddress")]
        public ActionResult DeleteAddress(int AddressId)
        {
            try
            {
                string result = this.addressBL.DeleteAddress(AddressId);
                if (result.Equals("Address deleted successfully"))
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

        [HttpGet("GetAllAddress")]
        public ActionResult GetAllAddress()
        {
            try
            {
                var result = this.addressBL.GetAllAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Addresses are : ", response = result });
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

        [HttpGet("GetAddressById")]
        public ActionResult GetAddressById(int id)
        {
            try
            {
                var result = this.addressBL.GetAddressById(id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "This is the address : ", response = result });
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
