using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL:IAdminBL
    {
        IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        public ResAdminLogin AdminLogin(AdminModel adminModel)
        {
            try
            {
                return this.adminRL.AdminLogin(adminModel);
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }
    }
}
