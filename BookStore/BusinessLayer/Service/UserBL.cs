using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL:IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public void addUser(UserModel usermodel)
        {
            try
            {
                this.userRL.addUser(usermodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string userLogin(LoginModel loginModel)
        {
            try
            {
                return this.userRL.userLogin(loginModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool forgotPassword(string emailid)
        {
            try
            {
                return this.userRL.forgotPassword(emailid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void resetPassword(string EmailId, string Password)
        {
            try
            {
                this.userRL.resetPassword(EmailId, Password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
