using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206
{
    static class Storage
    {
        public static List<Student> Students = new List<Student>();
        public static List<StudentGroup> Groups = new List<StudentGroup>();
        public static List<Meeting> Meetings = new List<Meeting>();
        public static List<Class> Classes = new List<Class>();

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
