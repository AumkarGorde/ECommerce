using Dapper;
using ecommerce.data.Model;
using ecommerce.repo.Interface;
using System.Data.SqlClient;
using System.Linq;

namespace ecommerce.repo.Execution
{
    public class UserRepo:BaseRepo,IUserRepo
    {
        private readonly string dbConncetion;
        public UserRepo()
        {
            dbConncetion = DBConnection;
        }

        public UserModelSecret AuthenticateUser(User user)
        {
            var obj = authenticateUser(user.UserName, user.Password);
            if (obj is null)
                return null;
            else
                return obj;
        }

        public UserModelSecret RegisterUser(UserModelSecret user)
        {
            if (!checkUserExist(user.UserName))
            {
                user.Id = GenerateId();
                user.Role = "Normal User";
                using (var connection = new SqlConnection(dbConncetion))
                {
                    connection.Open();
                    var queryInsert = @"INSERT INTO USERS(Id, UserName, Password, Role) VALUES (@Id, @UserName, @Password, @Role)";
                    connection.Execute(queryInsert, user);
                    connection.Close();
                }
            }
            else
            {
                return null;
            }

            return user;
        }

        private bool checkUserExist(string userName)
        {
            bool result = false;
            using (var connection = new SqlConnection(dbConncetion))
            {
                connection.Open();
                var queryCheck = "SELECT TOP 1 UserName FROM Users WHERE UserName = @UserName";
                var res = connection.Query<string>(queryCheck,new { UserName = userName}).AsList();
                if (res.Count != 0)
                    result = true;
                connection.Close();
            }
            return result;
        }

        private UserModelSecret authenticateUser(string userName, string password)
        {
            using (var connection = new SqlConnection(dbConncetion))
            {
                connection.Open();
                var queryCheck = "SELECT TOP 1 UserName, Password, Role FROM Users WHERE UserName = @UserName COLLATE SQL_Latin1_General_CP1_CS_AS and Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";
                var res = connection.Query<UserModelSecret>(queryCheck, new { UserName = userName, Password = password }).AsList().FirstOrDefault();
                if (res != null)
                    return res;
                connection.Close();
            }
            return null;
        }
    }
}
