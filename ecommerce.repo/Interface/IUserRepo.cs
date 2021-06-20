using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.repo.Interface
{
    public interface IUserRepo
    {
        public UserModelSecret RegisterUser(UserModelSecret user);

        public UserModelSecret AuthenticateUser(User user);
    }
}
