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
            int ID = 650432; // As the user would be logged in, constantly being stored makes sense
            Student user = null;
            StudentGroup group = null;
            Meeting meeting = null;
            Class @class = null;

            user = Storage.GetStudent(ID);

            group = Storage.GetGroup(user.StudentGroup);
            meeting = Storage.GetMeeting(group.GroupID);
            @class = Storage.GetClass(group.GroupID);



            foreach (Student student in Storage.Students)
            {
                Console.WriteLine(student.ToString());
                group = Storage.GetGroup(student.StudentGroup);
                Console.WriteLine(group.ToString());
                meeting = Storage.GetMeeting(group.GroupID);
                Console.WriteLine(meeting.ToString());
                @class = Storage.GetClass(student.StudentGroup);
                Console.WriteLine(@class.ToString());

                Console.WriteLine();

            }
        }
    }
}
