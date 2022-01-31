﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace PizzaDALLibrary
{
    class MyConnection
    {
        SqlConnection conn;
        static MyConnection connection;
        private MyConnection()
        {
            conn = new SqlConnection(ConfigurationManager ConnectionsStrings["conn"].ConnectionString);

        }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MyConnection();
            return connection.conn;
        }
    }
}
