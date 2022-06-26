using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IAdminRL
    {
        public ResAdminLogin AdminLogin(AdminModel adminModel);
    }
}
