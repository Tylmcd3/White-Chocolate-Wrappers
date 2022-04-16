using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206
{
    static class Storage
    {
        public static List<Student> Students = new List<Student>()
        {
           new Student(100562,"Julian","Brown", 938475, "Dr",Campus.Hobart, "Julian@email.com", Category.Batchelors),
           new Student(650432,"Tyler", "McDonald",118234, "Mr", Campus.Hobart, "Tyler@email.com", Category.Batchelors),
           new Student(375002 ,"Tilly", "Doggy", 118234, "Pup", Campus.Hobart, "Tilly@email.com", Category.Masters ),
           new Student(123456, "Percy", "Jackson",938475, "Mr", Campus.Lauceston, "Percy@email.com", Category.Masters )

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
            Students.Add(student);
        }
        public static void AddGroup(StudentGroup group)
        {
            Groups.Add(group);
        }
        public static void AddMeeting(Meeting meeting)
        {
            Meetings.Add(meeting);
        }
        public static void AddClasses(Class Class)
        {
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
        public static Class GetClass(int id)
        {
            foreach (Class Class in Classes)
                if (Class.GroupID == id)
                    return Class;
            return null;
        }
    }
}
