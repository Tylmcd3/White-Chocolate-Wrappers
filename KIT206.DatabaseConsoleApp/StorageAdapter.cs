using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.DatabaseApp
{
    class StorageAdapter
    {
        //Student Storage Functions

        public static List<Student> LoadStudents()
        {
            List<Student> students = new List<Student>();
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = "SELECT * FROM student";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                if ((string)rdr[7] != "")
                {
                    students.Add(new Student(
                        (int)rdr[0],
                        (string)rdr[1], (string)rdr[2],
                        (int)rdr[3],
                        (string)rdr[4],
                        (string)rdr[6],
                        Enum.Parse<Campus>((string)rdr[5]),
                        (string)rdr[7],
                        Enum.Parse<Category>((string)rdr[9])));
                }
                else
                {
                    students.Add(new Student((int)rdr[0], (string)rdr[1], (string)rdr[2]));
                }
            }

            MySQLConnector.DBClose(rdr, conn);
            return students;
        }

        //Edit Student group of given student
        public static void EditStudentGroupMembership(Student student)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = ("UPDATE student SET group_id =" + student.StudentGroup + "WHERE student_id = " + student.StudentID);

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Edit Student details of given student
        public static void EditStudentDetails(Student student)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE student SET " +
                $"title = \"{student.Title}\", " +
                $"campus = \'{student.Campus.ToString()}\', " +
                $"phone = \"{student.Phone}\", " +
                $"email = \"{student.Email}\"," +
                $"category = \'{student.Category.ToString()}\' " +
                $"WHERE student_id = " + student.StudentID;

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


        //Wasnt sure if we need to be able to add groups?

        public static void AddGroup(StudentGroup group)
        {

        }

        //Edits group name of given group
        public static void EditGroup(StudentGroup group)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE studentGroup SET group_name = " + group.GroupName + " WHERE group_id = " + group.GroupID;

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
                group = new StudentGroup((int)rdr[0], (string)rdr[1]);
            }

            MySQLConnector.DBClose(rdr, conn);
            return group;
        }

        //Returns all Student Groups
        public static List<StudentGroup> LoadGroups()
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            List<StudentGroup> groups = null;
            string sqlcmd = "SELECT * FROM `studentGroup`";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                groups.Add(new StudentGroup((int)rdr[0], (string)rdr[1]));

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
                    (TimeSpan)rdr[3],
                    (TimeSpan)rdr[4],
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
            List<Meeting> meetings = new List<Meeting>();
            string sqlcmd = "SELECT * FROM meeting WHERE group_id=" + groupID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                if(rdr != null)
                {
                    meetings.Add(new Meeting(
                        (int)rdr[0],
                        (int)rdr[1],
                        Enum.Parse<Day>((string)rdr[2]),
                        (TimeSpan)rdr[3],
                        (TimeSpan)rdr[4],
                        (string)rdr[5]
                        ));
                }

            }

            MySQLConnector.DBClose(rdr, conn);
            return meetings;
        }

        public static void AddMeeting(Meeting meeting)
        {
            //TODO add meeting to database - do we actualyl add it?
        }

        public static void EditMeeting(Meeting meeting)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Console.WriteLine(meeting.End);
            string sqlcmd = $"UPDATE `meeting` SET " +
                $"day = \'{meeting.Day}\', " +
                $"start = \'{meeting.Start}\', " +
                $"end = \'{meeting.End}\', " +
                $"room = \"{meeting.Room}\" " +
                $"WHERE meeting_id = " + meeting.MeetingID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        public static void RemoveMeeting(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"DELETE * from `meeting` WHERE meeting_id = " + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySQLConnector.DBExecute(cmd, conn);
        }

        //This could be changed to group id?
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

        //TODO dont think we need this function:
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
    }
}
