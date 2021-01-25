using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceKMIDSSmart.Operation
{
    public class config
    {
        string connncet = Properties.Settings.Default.Database;
        public SqlConnection DBconnect()
        {
            var conn = new SqlConnection(connncet);
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}