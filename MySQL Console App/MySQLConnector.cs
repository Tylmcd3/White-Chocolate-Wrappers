using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MySQL
{
    class MySQLConnector
    {
        private const string db = "gmis";
        private const string user = "kit206g6";
        private const string pass = "group6";
        private const string server = "alacritas.cis.utas.edu.au";

        static MySqlConnection DatabaseConnect()
        {
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            return new MySqlConnection(connectionString);
        }


    }
}
