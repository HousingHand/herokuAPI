using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HHPassport.ClassicAPI.Service
{
    public class HostBuilder
    {
        public static string GetConnectionString(string environment)
        {
            string connectionString = string.Empty;
            if (environment == "Development")
            {
                connectionString = ConfigurationManager.ConnectionStrings["DevelopmentConnection"].ConnectionString;
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            return connectionString;
        }
    }
}