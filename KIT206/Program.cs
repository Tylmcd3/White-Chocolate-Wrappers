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
            Student user;
            StudentGroup group = null;
            Meeting meeting = null;
            Class @class = null;
            int ID = 69; // As the user would be logged in, constantly being stored makes sense
            user = new Student("John", ID);
            Storage.AddStudent(user);
            group = user.AddGroup("White Chocolate Wrappers");
            Storage.AddGroup(group); 
            meeting = group.AddMeeting();
            Storage.Meetings.Add(meeting);
            @class = group.AddClass();
            Storage.AddClasses(@class);



            foreach (Student student in Storage.Students)
            {
                Console.WriteLine(student.ToString());
                group = Storage.GetGroup(student.StudentGroup);
                Console.WriteLine(group.ToString());
                meeting = Storage.GetMeeting(group.GroupID);
                Console.WriteLine(meeting.ToString());
                @class = Storage.GetClass(student.StudentGroup);
                Console.WriteLine(@class.ToString());

            }
        }
    }
}
