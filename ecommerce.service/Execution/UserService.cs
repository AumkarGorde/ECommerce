using ecommerce.data.Model;
using ecommerce.foundation;
using ecommerce.repo.Interface;
using ecommerce.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.service.Execution
{
    public class UserService : BaseService, IUserService
    {
        IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public UserModelSecret AuthenticateUser(User user)
        {
            var obj = _userRepo.AuthenticateUser(user);
            if (obj is null)
            {
                return null;
            }
            else
            {
                //generate token 
                TokenGenration tokenGenration = new TokenGenration(obj.UserName, obj.Role);
                obj.Token = tokenGenration.GenerateToken();
                obj.UserName = user.UserName;
                obj.Password = "*****";
            }

            return obj;
        }

        public UserModelSecret RegisterUser(UserModel user)
        {
            UserModelSecret userModel = new UserModelSecret()
            {
                UserName = user.UserName,
                Password = user.Password
            };
            return _userRepo.RegisterUser(userModel); ;
        }
    }
}
