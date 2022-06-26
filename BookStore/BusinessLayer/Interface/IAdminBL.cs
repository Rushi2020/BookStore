using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        public ResAdminLogin AdminLogin(AdminModel adminModel);
    }
}
