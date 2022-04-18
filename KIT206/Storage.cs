using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.Data
{
    static class Storage
    {
        public static List<Student> Students = new List<Student>()
        {
           new Student(100562,"Julian","Brown", 938475, "Dr",   "0443657473" ,Campus.Hobart, "Julian@email.com", Category.Batchelors),
           new Student(650432,"Tyler", "McDonald",118234, "Mr", "0447637153" ,Campus.Hobart, "Tyler@email.com", Category.Batchelors),
           new Student(375002 ,"Tilly", "Doggy", 118234, "Pup", "0449987423" ,Campus.Hobart, "Tilly@email.com", Category.Masters ),
           new Student(123456, "Percy", "Jackson",938475, "Mr", "0445655451" ,Campus.Lauceston, "Percy@email.com", Category.Masters ),
           new Student(213243, "Testing", "Account")

        };
        public static List<StudentGroup> Groups = new List<StudentGroup>()
        {
            new StudentGroup("Trains", 938475),
            new StudentGroup("Control Freaks", 118234)
        };
        public static List<Meeting> Meetings = new List<Meeting>()
        {
            new Meeting(728342,938475, Day.Monday, new DateTime(2022, 4, 18, 10,0,0),new DateTime(2022, 4, 18, 11,0,0), "cen.275"),
            new Meeting(192384,938475, Day.Wednesday, new DateTime(2022, 4, 20, 10,0,0),new DateTime(2022, 4, 20, 11,0,0), "cen.275"),
            new Meeting(093847,118234, Day.Thursday, new DateTime(2022, 4, 21, 12,0,0),new DateTime(2022, 4, 21, 13,30,0), "cen.272"),
            new Meeting(462837,118234, Day.Saturday, new DateTime(2022, 4, 23, 12,0,0),new DateTime(2022, 4, 23, 13,30,0), "cen.272"),
            new Meeting(192837,118234, Day.Sunday, new DateTime(2022, 4, 24, 12,0,0),new DateTime(2022, 4, 24, 13,30,0), "cen.272")

        };
        public static List<Class> Classes = new List<Class>()
        {
            new Class(823347,938475, Day.Tuesday, new DateTime(2022, 1, 1, 13,0,0),new DateTime(2022, 1, 1, 14,0,0), "cen.275"),
            new Class(172236,118234, Day.Friday, new DateTime(2022, 1, 1, 9,0,0),new DateTime(2022, 1, 1, 11,0,0), "cen.275"),
        };

        public static void AddStudent(Student student)
        {
            if(student != null)
                Students.Add(student);
        }
        public static void AddGroup(StudentGroup group)
        {
            if (group != null)
                Groups.Add(group);
        }
        public static void AddMeeting(Meeting meeting)
        {
            if (meeting != null)
                Meetings.Add(meeting);
        }
        public static void AddClasses(Class Class)
        {
            if (Class != null)
                Classes.Add(Class);
        }
        //All these edit function are destructive and not really what we want but it works for now,
        //The MySQL implementation will include either a function for each field that can be changed or something else idk
        public static void EditStudent(Student student)
        {
            Students.RemoveAll(stu => stu.StudentID == student.StudentID);
            Students.Add(student);
        }
        public static void EditGroup(StudentGroup group)
        {
            Groups.RemoveAll(gru => gru.GroupID == group.GroupID);
            Groups.Add(group);
        }
        public static void EditMeeting(Meeting meeting)
        {
            Meetings.RemoveAll(meet => meet.MeetingID == meeting.MeetingID);
            Meetings.Add(meeting);
        }
        public static void EditClasses(Class Class)
        {
            Classes.RemoveAll(cla => cla.ClassID == Class.ClassID);
            Classes.Add(Class);
        }

        public static Student GetStudent(int id)
        {
            foreach (Student student in Students)
                if (student.StudentID == id)
                    return student;
            return null;
        }
        public static StudentGroup GetGroup(int id)
        {
            foreach (StudentGroup group in Groups)
                if (group.GroupID == id)
                    return group;
            return null;
        }
        public static Meeting GetMeeting(int id)
        {
            foreach (Meeting meeting in Meetings)
                if (meeting.GroupID == id)
                    return meeting;
            return null;
        }
  
        public static Meeting GetMeeting(DateTime start)
        {
            foreach (Meeting meeting in Meetings)
                if (meeting.Start == start)
                {
                    return meeting;
                }
            return null;
                    

        }

        public static Class GetClass(int id)
        {
            foreach (Class Class in Classes)
                if (Class.GroupID == id)
                    return Class;
            return null;
        }
    }
}
