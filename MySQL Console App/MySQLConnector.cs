using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace KIT206.Data
{
    class Storage
    {
        private const string db = "gmis";
        private const string user = "kit206g6";
        private const string pass = "group6";
        private const string server = "alacritas.cis.utas.edu.au";

        static MySqlConnection DatabaseConnect()
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

        static MySqlDataReader DBQuery(MySqlCommand cmd, MySqlConnection conn)
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

        public static Student GetStudent(int id)
        {
            MySqlConnection conn = DatabaseConnect();
            string sqlcmd = ("select * from student WHERE student_id = "+id);
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            Student student = null;

            MySqlDataReader rdr = DBQuery(cmd, conn);
            while (rdr.Read())
            {
                if(rdr[3] != null)
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2], (int)rdr[3], (string)rdr[4], (string)rdr[6], Enum.Parse<Campus>((string)rdr[5]), (string)rdr[7], Enum.Parse<Category>((string)rdr[9]));
                }
                else
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2]);
                }
            }

            rdr.Close();
            conn.Close();
            return student;
        }
        public static Student GetGroup(int id)
        {
            MySqlConnection conn = DatabaseConnect();
            string sqlcmd = ("select * from student WHERE student_id = " + id);
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            Student student = null;

            MySqlDataReader rdr = DBQuery(cmd, conn);
            while (rdr.Read())
            {
                if (rdr[3] != null)
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2], (int)rdr[3], (string)rdr[4], (string)rdr[6], Enum.Parse<Campus>((string)rdr[5]), (string)rdr[7], Enum.Parse<Category>((string)rdr[9]));
                }
                else
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2]);
                }
            }

            rdr.Close();
            conn.Close();
            return student;
        }
        
    }
}
