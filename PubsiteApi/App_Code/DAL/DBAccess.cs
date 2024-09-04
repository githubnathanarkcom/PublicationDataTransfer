using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PubsiteApi.App_Code.DAL
{
    public class DBAccess
    {
        private SqlCommand cmd = new SqlCommand();
        private string strConnectionString = "";
         
 
        public DBAccess()
        {
            ConnectionStringSettings objConnectionStringSettings = ConfigurationManager.ConnectionStrings["MyConnenction"];
            strConnectionString = objConnectionStringSettings.ConnectionString;
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = strConnectionString;
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
        }
    }
}