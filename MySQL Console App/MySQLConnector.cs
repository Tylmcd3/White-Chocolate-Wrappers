using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace KIT206
{
    class MySQLConnector
    {
        private const string db = "gmis";
        private const string user = "kit206g6";
        private const string pass = "group6";
        private const string server = "alacritas.cis.utas.edu.au";

        public static MySqlConnection DatabaseConnect()
        {
            MySqlConnection conn = null;
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch
            {
                Console.WriteLine("Cannot Connect to the database {0}", db);
            }
            return conn;
        }

        public static MySqlDataReader DBReader(MySqlCommand cmd, MySqlConnection conn)
        {

            MySqlDataReader rdr = null;
            conn.Open();
            try
            {
                rdr = cmd.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return rdr;
        }
        public static void DBExecute(MySqlCommand cmd, MySqlConnection conn)
        {

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error - could not execute query", ex);
            }
            finally 
            { 
                conn.Close(); 
            }
        }


        public static void DBClose(MySqlDataReader rdr, MySqlConnection conn)
        {
            rdr.Close();
            conn.Close();
        }

        
        
        
    }
}
