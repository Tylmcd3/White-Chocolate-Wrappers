using System;
using System.Collections.Generic;

namespace KIT206
{
    public class Controller
    {
        public List<StudentGroup> groups;
        public List<Student> students;
        public List<Class> classes;
        public List<Meeting> meetings;

        public void AddClass(StudentGroup group)
        {
            string startTime, endTime, room;
            DateTime start, end;
            Day day;

            Console.WriteLine("Enter the Start time of the Class in 24HR time (HH:MM dd/mm/yyyy):  ");
            startTime = Console.ReadLine();
            Console.WriteLine("Enter the End time of the Class (HH:MM dd/mm/yyyy):  ");
            endTime = Console.ReadLine();
            Console.WriteLine("Enter the Room Code");
            room = Console.ReadLine();

            start = DateTime.Parse(startTime);
            end = DateTime.Parse(endTime);
            day = (Day)Enum.ToObject(typeof(Day), (int)start.DayOfWeek);

            Class toAdd = new Class(group.GroupID, day, start, end, room);
            classes.Add(toAdd);
            StorageAdapter.AddClass(toAdd);

            //Generate class id
            //TODO move ID generator to controller
            //Get Class details
            //Push to List
            //Finally add to database
        }

        public Controller()
        {
            groups = StorageAdapter.GetGroups();
            classes = StorageAdapter.GetClasses();
        }
    }
}
