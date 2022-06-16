using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;

        public UserController(IUserBL userBL)
        {

            this.userBL = userBL;

        }
        [HttpPost("register")]
        public ActionResult RegisterUser(UserModel usermodel)
        {
            try
            {
                this.userBL.addUser(usermodel);
                return this.Ok(new { success = true, message = $"Registration Successful  {usermodel.EmailId}" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("userLogin")]
        public ActionResult LogInUser(LoginModel loginModel)
        {
            try
            {
                string result = this.userBL.userLogin(loginModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"LogIn Successful {loginModel.EmailId}, data = {result}" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Enter Valid Email and Password" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut("forgotpassword")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var result = this.userBL.forgotPassword(email);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, message = "Email is invalid" });
                }
                else
                {

                    return this.Ok(new { success = true, message = "Token sent succesfully to email for password reset" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [Authorize]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword(string password)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    this.userBL.resetPassword(userEmail, password);

                    return Ok(new { Success = true, message = "Password reset successfully" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Password reset Unsuccesfully" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
