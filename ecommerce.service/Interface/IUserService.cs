using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.service.Interface
{
    public interface IUserService
    {
        public bool RegisterUser(UserModel user);
        public UserModelSecret AuthenticateUser(UserModel user);
    }
}
