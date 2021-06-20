using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.repo.Interface
{
    public interface IUserRepo
    {
        public bool RegisterUser(UserModelSecret user);

        public UserModelSecret AuthenticateUser(UserModel user);
    }
}
