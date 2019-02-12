using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarsStore.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _mode;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["CarStore"].ConnectionString;

            return _connectionString;
        }

        public static string GetRepoMode()
        {
            if (string.IsNullOrEmpty(_mode))
                _mode = ConfigurationManager.AppSettings["Mode"].ToString();

            return _mode;
        }
        
    }
}