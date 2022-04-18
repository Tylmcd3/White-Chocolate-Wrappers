using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206.Data;
using MySql.Data.MySqlClient;

namespace KIT206
{
    class StorageAdapter
    {
        //Student Storage Functions

        //I dont remember if we actually need this as we never actually create new users. 
        //I wont delete it yet though
        //public static void AddStudent(Student student)
        //{
        //    Storage.AddStudent(student);
        //}
        public static void EditStudentGroup(int id, int group_id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = ("UPDATE student SET group_id =" + group_id + "WHERE student_id = " + id);

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySQLConnector.DBExecute(cmd, conn);
        }
        public static void EditStudentDetails(int id, string title, Campus campus, Category category, string email, string phone)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE student SET title ={title}, campus = {campus.ToString()}, phone = {phone}, email = {email},category = {category.ToString()} WHERE student_id = " + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySQLConnector.DBExecute(cmd, conn);
        }
        public static Student GetStudent(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = ("select * from student WHERE student_id = " + id);
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            Student student = null;
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);
            while (rdr.Read())
            {
                if (rdr[7] != "")
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2], (int)rdr[3], (string)rdr[4], (string)rdr[6], Enum.Parse<Campus>((string)rdr[5]), (string)rdr[7], Enum.Parse<Category>((string)rdr[9]));
                }
                else
                {
                    student = new Student((int)rdr[0], (string)rdr[1], (string)rdr[2]);
                }
            }
            MySQLConnector.DBClose(rdr, conn);
            return student;
        }
        //Group Functions
        //public static void AddGroup(StudentGroup group)
        //{
        //    Storage.AddGroup(group);
        //}
        //public static void EditGroup(StudentGroup group)
        //{
        //    Storage.EditGroup(group);
        //}
        public static StudentGroup GetGroup(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = "SELECT * FROM `studentGroup` WHERE group_id=" + id;
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            StudentGroup group = null;

            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);
            while (rdr.Read())
            {
                group = new StudentGroup((string)rdr[1], (int)rdr[0]);

            }

            MySQLConnector.DBClose(rdr, conn);
            return group;
        }
        public static List<StudentGroup> GetGroups()
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = "SELECT * FROM `studentGroup`";
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            List<StudentGroup> groups = null;

            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);
            while (rdr.Read())
            {
                groups.Add(new StudentGroup((string)rdr[1], (int)rdr[0]));

            }

            MySQLConnector.DBClose(rdr, conn);
            return groups;
        }
        //Meeting functions
        //public static void AddMeeting(Meeting meeting)
        //{
        //    Storage.AddMeeting(meeting);
        //}
        //public static void EditMeeting(Meeting meeting)
        //{
        //    Storage.EditMeeting(meeting);
        //}
        //public static Meeting GetMeeting(DateTime start)
        //{
        //    return Storage.GetMeeting(start);
        //}
        //Class functions
        //public static void AddClasses(Class Class)
        //{
        //    Storage.AddClasses(Class);
        //}
        //public static void EditClasses(Class Class)
        //{
        //    Storage.EditClasses(Class);
        //}
        //public static Class GetClass(int id)
        //{
        //    return Storage.GetClass(id);
        //}
    }
}
