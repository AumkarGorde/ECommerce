using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.data.Model
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

    public class UserModelSecret : UserModel
    {
        public string Id { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
