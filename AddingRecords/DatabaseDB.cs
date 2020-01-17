using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace AddingRecords
{
    public static class DatabaseDB
    {
        public static SqlConnection GetConnection()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MMABooksConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(strConn);
            return Conn;
        }
    }
}
