using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL
{
    class StudentGroup_Controller
    {
        public List<StudentGroup> groups;

        private void UpdateGroups()
        {
            groups = StorageAdapter.GetGroups();
        }
        public Class AddClass()
        {
            string StartTime, EndTime, Room;
            DateTime Start, End;
            Day day;

            Console.WriteLine("Enter the Start time of the Class in 24HR time (HH:MM dd/mm/yyyy):  ");
            StartTime = Console.ReadLine();
            Console.WriteLine("Enter the End time of the Class (HH:MM dd/mm/yyyy):  ");
            EndTime = Console.ReadLine();
            Console.WriteLine("Enter the Room Code");
            Room = Console.ReadLine();
            Start = DateTime.Parse(StartTime);
            End = DateTime.Parse(StartTime);
            day = (Day)Enum.ToObject(typeof(Day), (int)Start.DayOfWeek);

            return new Class(GroupID, day, Start, End, Room);
        }

        public Meeting AddMeeting()
        {
            string StartTime, EndTime, Room;
            DateTime Start, End;
            Day day;



            Console.WriteLine("Enter the Start time of the meeting in 24HR time (HH:MM dd/mm/yyyy):  ");
            StartTime = Console.ReadLine();

            Console.WriteLine("Enter the End time of the meeting (HH:MM dd/mm/yyyy):  ");
            EndTime = Console.ReadLine();

            Console.WriteLine("Enter the Room Code");
            Room = Console.ReadLine();
            Start = DateTime.Parse(StartTime);
            End = DateTime.Parse(StartTime);
            day = (Day)Enum.ToObject(typeof(Day), (int)Start.DayOfWeek);


            return new Meeting(GroupID, day, Start, End, Room);
        }


        public override string ToString()
        {
            return (GroupName + "'s ID is " + GroupID);
        }
        //This needs to be added to the StorageAdapters, was slack of me
        public static StudentGroup GetGroup(Student student, List<StudentGroup> groups)
        {
            int id = student.StudentGroup;

            foreach (StudentGroup group in groups)
            {
                if (group.GroupID == id)
                {
                    return group;
                }
            }
            return null;

        }
        public void EditGroup(string new_name)
        {
            GroupName = new_name;
        }
        //also needs to be added to storageAdapters, stops this getting a list of all groups to then return one.
        public static StudentGroup GetGroup(int id, List<StudentGroup> groups)
        {
            foreach (StudentGroup group in groups)
            {
                if (group.GroupID == id)
                {
                    return group;
                }
            }
            return null;

        }
        //This can be in the Group Controller but the searching needs to be done in the Database controller
        //public List<Student> GetGroupMembers(int StudentID)
        //{
        //    List<Student> students = new List<Student>();
        //    foreach (Student student in StorageAdapter.Students)
        //    {
        //        if (student.StudentGroup == GroupID && student.StudentID != StudentID)
        //        {
        //            students.Add(student);
        //        }
        //    }
        //    return students;
        //}
        //Same for this
        //public List<Meeting> GetMeetings()
        //{
        //    List<Meeting> Meetings = new List<Meeting>();
        //    foreach (Meeting meeting in StorageAdapter.Meetings)
        //    {

        //        if (meeting.GroupID == GroupID)
        //        {
        //            Meetings.Add(meeting);
        //        }
        //    }
        //    return Meetings;
        //}
    }
}
