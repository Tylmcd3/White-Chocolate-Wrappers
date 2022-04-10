using System;
using System.Collections.Generic;
using System.Globalization;

namespace KIT206
{
    class Program
    {
        //Driver Class
        static void Main(string[] args)
        {
            int ID = 69; // As the user would be logged in, constantly being stored makes sense
            Student user = new Student("John", ID); 
            StudentGroup group = null;
            Meeting meeting = null;
            Storage.AddStudent(user);
            group = user.AddGroup("White Chocolate Wrappers");
            Storage.AddGroup(group);
            meeting = group.AddMeeting();
            Storage.Meetings.Add(meeting);

            foreach (Student student in Storage.Students)
            {
                Console.WriteLine(student.ToString());
                group = Storage.GetGroup(student.StudentGroup);
                Console.WriteLine(group.ToString());
                meeting = Storage.GetMeeting(group.GroupID);
                Console.WriteLine(meeting.ToString());
            }
        }
    }
}
