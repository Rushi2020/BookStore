using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
         IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("Login")]
        public ActionResult AdminModel(AdminModel adminModel)
        {
            try
            {

                var res = adminBL.AdminLogin(adminModel);
                if (res != null)
                {
                    return Ok(new { success = true, message = "Login done sucessfully", data = res });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to Login" });
                }
            }
            catch (Exception Ex)
            {

                return NotFound(new { Success = false, message = Ex.Message });
            }
        }
    }
}
