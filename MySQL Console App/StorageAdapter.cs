using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //Edit Student group of given student
        public static void EditStudentGroup(int id, int group_id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = ("UPDATE student SET group_id =" + group_id + "WHERE student_id = " + id);

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Edit Student details of given student
        public static void EditStudentDetails(int id, string title, Campus campus, Category category, string email, string phone)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE student SET title ={title}, campus = {campus.ToString()}, phone = {phone}, email = {email},category = {category.ToString()} WHERE student_id = " + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Returns given Student
        public static Student GetStudent(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Student student = null;
            string sqlcmd = ("SELECT * from student WHERE student_id = " + id);

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                //Checks if a student has filled out details or not
                if ((string)rdr[7] != "")
                {
                    student = new Student(
                        (int)rdr[0],
                        (string)rdr[1], (string)rdr[2],
                        (int)rdr[3],
                        (string)rdr[4],
                        (string)rdr[6],
                        Enum.Parse<Campus>((string)rdr[5]),
                        (string)rdr[7],
                        Enum.Parse<Category>((string)rdr[9]));
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

        //Wasnt sure if we need to be able to add groups?

        //Edits group name of given group
        public static void EditGroup(int id, string name)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE studentGroup SET group_name = " + name + " WHERE group_id = " + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Returns Student Group given Group ID
        public static StudentGroup GetGroup(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            StudentGroup group = null;
            string sqlcmd = "SELECT * FROM `studentGroup` WHERE group_id=" + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                group = new StudentGroup((string)rdr[1], (int)rdr[0]);
            }

            MySQLConnector.DBClose(rdr, conn);
            return group;
        }

        //Returns all Student Groups
        public static List<StudentGroup> GetGroups()
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            List<StudentGroup> groups = null;
            string sqlcmd = "SELECT * FROM `studentGroup`";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                groups.Add(new StudentGroup((string)rdr[1], (int)rdr[0]));

            }

            MySQLConnector.DBClose(rdr, conn);
            return groups;
        }

        //Returns meeting given meeting id
        public static Meeting GetMeeting(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Meeting meeting = null;
            string sqlcmd = "SELECT * FROM `meeting` WHERE meeting_id=" + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                meeting = new Meeting(
                    (int)rdr[0],
                    (int)rdr[1],
                    Enum.Parse<Day>((string)rdr[2]),
                    (DateTime)rdr[3],
                    (DateTime)rdr[4],
                    (string)rdr[5]
                    );
            }

            MySQLConnector.DBClose(rdr, conn);
            return meeting;

        }

        //Returns list of meetings in given group
        public static List<Meeting> GetMeetings(int groupID)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            List<Meeting> meetings = null;
            string sqlcmd = "SELECT * FROM `meeting` WHERE group_id=" + groupID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                meetings.Add(new Meeting(
                    (int)rdr[0],
                    (int)rdr[1],
                    Enum.Parse<Day>((string)rdr[2]),
                    (DateTime)rdr[3],
                    (DateTime)rdr[4],
                    (string)rdr[5]
                    ));
            }

            MySQLConnector.DBClose(rdr, conn);
            return meetings;
        }

        //Returns Class given class id
        public static Class GetClass(int classID)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Class returnClass = null;
            string sqlcmd = "SELECT * FROM `class` WHERE class_id=" + classID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                returnClass = new Class(
                    (int)rdr[0],
                    (int)rdr[1],
                    Enum.Parse<Day>((string)rdr[2]),
                    (DateTime)rdr[3],
                    (DateTime)rdr[4],
                    (string)rdr[5]);
            }

            MySQLConnector.DBClose(rdr, conn);
            return returnClass;
        }

        //Returns all Classes 
        public static List<Class> GetClasses()
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            List<Class> classes = null;
            string sqlcmd = "SELECT * FROM `class`";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                classes.Add(new Class(
                    (int)rdr[0],
                    (int)rdr[1],
                    Enum.Parse<Day>((string)rdr[2]),
                    (DateTime)rdr[3],
                    (DateTime)rdr[4],
                    (string)rdr[5]
                    ));
            }

            MySQLConnector.DBClose(rdr, conn);
            return classes;
        }

        public static void AddClass(Class toAdd)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            //Deconstruct toAdd into strings then add to db
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
