using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206.Data;

namespace KIT206
{
    class StorageAdapter
    {
        public static List<Student> Students { get => Storage.Students; }
        public static List<StudentGroup> Groups { get => Storage.Groups; }
        public static List<Meeting> Meetings { get => Storage.Meetings; }
        public static List<Class> Classes { get => Storage.Classes; }
        public static void AddStudent(Student student)
        {
            Storage.AddStudent(student);
        }
        public static void AddGroup(StudentGroup group)
        {
            Storage.AddGroup(group);
        }
        public static void AddMeeting(Meeting meeting)
        {
            Storage.AddMeeting(meeting);
        }
        public static void AddClasses(Class Class)
        {
            Storage.AddClasses(Class);
        }
        public static void EditStudent(Student student)
        {
            Storage.EditStudent(student);
        }
        public static void EditGroup(StudentGroup group)
        {
            Storage.EditGroup(group);
        }
        public static void EditMeeting(Meeting meeting)
        {
            Storage.EditMeeting(meeting);
        }
        public static void EditClasses(Class Class)
        {
            Storage.EditClasses(Class);
        }

        public static Student GetStudent(int id)
        {
            return Storage.GetStudent(id);
        }
        public static StudentGroup GetGroup(int id)
        {
            return Storage.GetGroup(id);
        }
        public static Meeting GetMeeting(int id)
        {
            return Storage.GetMeeting(id);
        }

        public static Meeting GetMeeting(DateTime start)
        {
            return Storage.GetMeeting(start);
        }

        public static Class GetClass(int id)
        {
            return Storage.GetClass(id);
        }
    }
}
