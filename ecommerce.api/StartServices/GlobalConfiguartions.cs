using ecommerce.foundation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.api
{
    public static class GlobalConfiguartions
    {
        public static void SetGlobalConfiguration(IConfiguration configuration)
        {
            ApplicationConfigurations.DBConnection = configuration.GetValue<string>("AppSettings:DBConnection");
            ApplicationConfigurations.SecretKey = configuration.GetValue<string>("AppSettings:SecretKey");
        }
    }
}
