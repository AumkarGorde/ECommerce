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

        public string GenerateId()
        {
            var ticks = new DateTime(1997, 5, 6).Ticks;
            var uid = DateTime.Now.Ticks - ticks;
            return uid.ToString("x");
        }
    }
}
