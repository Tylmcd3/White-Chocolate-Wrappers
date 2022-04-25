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
                        (string)rdr[1],
                        (string)rdr[2],
                        (rdr[3].GetType().Equals(1.GetType())) ? (int)rdr[3] : -1,
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

        //Returns given Student by ID
        //TODO might not need this one since we work from list
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


        //Group Methods


        //Returns Student Group given Group ID
        //TODO might not need this method
        public static StudentGroup LoadGroup(int id)
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
            List<StudentGroup> groups = new List<StudentGroup>();
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

        //Adds given group to database
        public static void AddGroup(StudentGroup group)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();

            string sqlcmd = "INSERT INTO studentGroup (group_id, group_name)" +
                $"VALUES (" +
                $"\'{group.GroupID}\', " +
                $"\'{group.GroupName}\')";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Edits group name of given group
        public static void EditGroup(StudentGroup group)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"UPDATE studentGroup SET group_name = " + group.GroupName + " WHERE group_id = " + group.GroupID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Meeting Methods

        //Returns meeting given meeting id
        public static Meeting LoadMeeting(int id)
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
        public static List<Meeting> LoadMeetings(int groupID)
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

        //Adds given meeting to database
        public static void AddMeeting(Meeting meeting)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();

            string sqlcmd = "INSERT INTO meeting (meeting_id, group_id, day, start, end, room)" +
                $"VALUES (" +
                $"\'{meeting.MeetingID}\', " +
                $"\'{meeting.GroupID}\', " +
                $"\'{meeting.Day.ToString()}\', " +
                $"\'{meeting.Start}\', " +
                $"\'{meeting.End}\', " +
                $"\"{meeting.Room}\")";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Updates meeting to given meeting
        public static void EditMeeting(Meeting meeting)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Console.WriteLine(meeting.End);
            string sqlcmd = $"UPDATE `meeting` SET " +
                $"day = \'{meeting.Day}\', " +
                $"start = \'{meeting.Start}\', " +
                $"end = \'{meeting.End}\', " +
                $"room = \"{meeting.Room}\" " +
                $"WHERE meeting_id = {meeting.MeetingID}";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }

        //Removes meeting from database
        public static void RemoveMeeting(int id)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            string sqlcmd = $"DELETE * from `meeting` WHERE meeting_id = " + id;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySQLConnector.DBExecute(cmd, conn);
        }

        //Class methods

        //Returns class by given groupID
        public static Class LoadClassByGroup(int groupID)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();
            Class returnClass = null;
            string sqlcmd = "SELECT * FROM `class` WHERE group_id=" + groupID;

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
            MySqlDataReader rdr = MySQLConnector.DBReader(cmd, conn);

            while (rdr.Read())
            {
                returnClass = new Class(
                    (int)rdr[0],
                    (int)rdr[1],
                    Enum.Parse<Day>((string)rdr[2]),
                    (TimeSpan)rdr[3],
                    (TimeSpan)rdr[4],
                    (string)rdr[5]);
            }

            MySQLConnector.DBClose(rdr, conn);
            return returnClass;
        }

        //Returns Class given class id
        //TODO might not need this method
        public static Class LoadClass(int classID)
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
                    (TimeSpan)rdr[3],
                    (TimeSpan)rdr[4],
                    (string)rdr[5]);
            }

            MySQLConnector.DBClose(rdr, conn);
            return returnClass;
        }

        //TODO dont think we need this function:
        //Returns all Classes 
        public static List<Class> LoadClasses()
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
                    (TimeSpan)rdr[3],
                    (TimeSpan)rdr[4],
                    (string)rdr[5]
                    ));
            }

            MySQLConnector.DBClose(rdr, conn);
            return classes;
        }

        //Addes given class to database
        public static void AddClass(Class toAdd)
        {
            MySqlConnection conn = MySQLConnector.DatabaseConnect();

            string sqlcmd = "INSERT INTO class (class_id, group_id, day, start, end, room)" +
                $"VALUES (" +
                $"\'{toAdd.ClassID}\', " +
                $"\'{toAdd.GroupID}\', " +
                $"\'{toAdd.Day.ToString()}\', " +
                $"\'{toAdd.Start}\', " +
                $"\'{toAdd.End}\', " +
                $"\"{toAdd.Room}\")";

            MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);

            MySQLConnector.DBExecute(cmd, conn);
        }
    }
}
