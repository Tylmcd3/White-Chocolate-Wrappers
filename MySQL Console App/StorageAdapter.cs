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
        //public static List<Student> Students { get => Storage.Students; }
        //public static List<StudentGroup> Groups { get => Storage.Groups; }
        //public static List<Meeting> Meetings { get => Storage.Meetings; }
        //public static List<Class> Classes { get => Storage.Classes; }
        //public static void AddStudent(Student student)
        //{
        //    Storage.AddStudent(student);
        //}
        //public static void AddGroup(StudentGroup group)
        //{
        //    Storage.AddGroup(group);
        //}
        //public static void AddMeeting(Meeting meeting)
        //{
        //    Storage.AddMeeting(meeting);
        //}
        //public static void AddClasses(Class Class)
        //{
        //    Storage.AddClasses(Class);
        //}
        //public static void EditStudent(Student student)
        //{
        //    Storage.EditStudent(student);
        //}
        //public static void EditGroup(StudentGroup group)
        //{
        //    Storage.EditGroup(group);
        //}
        //public static void EditMeeting(Meeting meeting)
        //{
        //    Storage.EditMeeting(meeting);
        //}
        //public static void EditClasses(Class Class)
        //{
        //    Storage.EditClasses(Class);
        //}

        public static Student GetStudent(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = ("select * from student WHERE student_id = " + id);
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            Student student = null;
            MySqlDataReader rdr = MySQLConnector.DBQuery(cmd, conn);
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
        public static StudentGroup GetGroup(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = "SELECT * FROM `studentGroup` WHERE group_id="+id;
            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            StudentGroup group = null;

            MySqlDataReader rdr = MySQLConnector.DBQuery(cmd, conn);
            while (rdr.Read())
            {
                group = new StudentGroup((string)rdr[1], (int)rdr[0]);

            }

            MySQLConnector.DBClose(rdr, conn);
            return group;
        }

        //public static Meeting GetMeeting(DateTime start)
        //{
        //    return Storage.GetMeeting(start);
        //}

        //public static Class GetClass(int id)
        //{
        //    return Storage.GetClass(id);
        //}
    }
}
