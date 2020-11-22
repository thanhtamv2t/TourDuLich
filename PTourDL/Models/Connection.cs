using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PTourDL.Models
{
    public class Connection
    {
        public static SqlConnection cnn;
        public static void connectDB()
        {
            string cString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
            cnn = new SqlConnection(cString);
            cnn.Open();
        }
    }
}