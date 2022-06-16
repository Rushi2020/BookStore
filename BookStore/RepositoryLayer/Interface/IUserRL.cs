﻿using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void addUser(UserModel usermodel);
        string userLogin(LoginModel loginModel);
        bool forgotPassword(string emailid);
        void resetPassword(string EmailId, string Password);
    }
}
