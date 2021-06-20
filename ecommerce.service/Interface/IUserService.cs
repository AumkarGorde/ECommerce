using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.service.Interface
{
    public interface IUserService
    {
        public UserModelSecret RegisterUser(UserModel user);
        public UserModelSecret AuthenticateUser(User user);
    }
}
