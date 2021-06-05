using System;

namespace ecommerce.repo
{
    public class BaseRepo
    {
        public string DBConnection = string.Empty;
        public BaseRepo()
        {
            DBConnection = "Data Source=DESKTOP-MBONB33;Initial Catalog=EComerceDB;Integrated Security=True";
        }
    }
}
