using System;
using System.Collections.Generic;

namespace KIT206.App
{
    public class Controller
    {
        //These act as temporary stores for data from the database
        //When the controller needs data it will first check these, and then the database

        //Could change student implementation because it is implied you can only access one
        //student account at a time. (i.e only store one student, and just grab that student at
        //start of session in driver class
        private List<StudentGroup> groups = new List<StudentGroup>();
        public List<Student> students = StorageAdapter.GetStudents();
        private List<Class> classes = new List<Class>();
        private List<Meeting> meetings = new List<Meeting>();


        //These methods check the Lists for the given object
        //If they cannot find them, they will return the object from the database,
        //And add that object to the list
        //This way the program only loads in what it needs, and then caches that 
        public StudentGroup GetStudentGroup(int groupID)
        {
            StudentGroup toAdd;
            foreach (StudentGroup group in groups)
            {
                if (group.GroupID == groupID)
                {
                    toAdd = group;
                    return toAdd;
                }
            }
            toAdd = StorageAdapter.GetGroup(groupID);
            groups.Add(toAdd);
            return toAdd;
        }

        public Class GetClass(int classID)
        {
            Class toAdd;
            foreach (Class classObject in classes)
            {
                if (classObject.ClassID == classID)
                {
                    toAdd = classObject;
                    return toAdd;
                }
            }
            toAdd = StorageAdapter.GetClass(classID);
            classes.Add(toAdd);
            return toAdd;
        }
        public Meeting GetMeeting(int meetingID)
        {
            Meeting toAdd;
            foreach (Meeting meeting in meetings)
            {
                if (meeting.MeetingID == meetingID)
                {
                    toAdd = meeting;
                    return toAdd;
                }
            }
            toAdd = StorageAdapter.GetMeeting(meetingID);
            meetings.Add(toAdd);
            return toAdd;
        }
        public Student GetStudent(int studentID)
        {
            Student toAdd;
            foreach (Student student in students)
            {
                if (student.StudentID == studentID)
                {
                    toAdd = student;
                    return toAdd;
                }
            }
            toAdd = StorageAdapter.GetStudent(studentID);
            students.Add(toAdd);
            return toAdd;
        }

        public void AddStudentDetails(int studentID)
        {
            string title, campus, email, category, phone;
            Student student = GetStudent(studentID);

            Console.WriteLine("Enter a title...");
            title = Console.ReadLine();

            Console.WriteLine("Enter a campus...");
            campus = Console.ReadLine();

            Console.WriteLine("Enter an email...");
            email = Console.ReadLine();

            Console.WriteLine("Enter a category (Bachelors/Masters)...");
            category = Console.ReadLine();

            Console.WriteLine("Enter a Phone Number...");
            phone = Console.ReadLine();

            student.Title = title;
            student.Campus = Enum.Parse<Campus>(campus);
            student.Email = email;
            student.Category = Enum.Parse<Category>(category);
            student.Phone = phone;

            //StorageAdapter.EditStudentDetails(student);

        }

        public void EditStudentGroupMembership(int studentID)
        {
            string groupID;
            Student student = GetStudent(studentID);

            Console.WriteLine("Enter a group ID...");
            groupID = Console.ReadLine();

            student.StudentGroup = Int32.Parse(groupID);
            //StorageAdapter.EditStudentGroupMembership(student);
        }

        //TODO Need to move ID Generators/Checkers to this class rather than inside the entity classes


        //Adds Class to database and list given details and validity
        public void AddClass(StudentGroup group)
        {
            //Check if group already has class attached, if so return 
            foreach(Class i in classes)
            {
                if(i.GroupID == group.GroupID)
                {
                    Console.WriteLine("Group already has class");
                    return;
                }
            }
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
            //StorageAdapter.AddClass(toAdd);
            
        }

        public void AddMeeting(StudentGroup group)
        {
            string startTime, endTime, room;
            DateTime start, end;
            Day day;

            Console.WriteLine("Enter the Start time of the Meeting in 24HR time (HH:MM dd/mm/yyyy):  ");
            startTime = Console.ReadLine();
            Console.WriteLine("Enter the End time of the Meeting (HH:MM dd/mm/yyyy):  ");
            endTime = Console.ReadLine();
            Console.WriteLine("Enter the Room Code");
            room = Console.ReadLine();

            start = DateTime.Parse(startTime);
            end = DateTime.Parse(endTime);
            day = (Day)Enum.ToObject(typeof(Day), (int)start.DayOfWeek);

            Meeting toAdd = new Meeting(group.GroupID, day, start, end, room);
            meetings.Add(toAdd);
            StorageAdapter.AddMeeting(toAdd);
        }

        public void EditMeeting(int meetingID)
        {
            Meeting meeting = GetMeeting(meetingID);

            string option, response;
            Console.WriteLine("What would you like to edit?\n[0] Day\n[1] Start time\n[2] End time\n");
            option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    Console.WriteLine("Enter a day...");
                    response = Console.ReadLine();
                    meeting.Day = Enum.Parse<Day>(response);
                    break;
                case "1":
                    Console.WriteLine("Enter a time...");
                    response = Console.ReadLine();
                    meeting.Start = DateTime.Parse(response);
                    meeting.Day = (Day)Enum.ToObject(typeof(Day), (int)meeting.Start.DayOfWeek);
                    break;

                case "2":
                    Console.WriteLine("Enter a time...");
                    response = Console.ReadLine();
                    meeting.End = DateTime.Parse(response);
                    break;
            }
            StorageAdapter.EditMeeting(meeting);
        }

        //TODO Cancel Meeting function

        public void AddGroup()
        {

            //Generate Group ID here, placeholder is 5
            int groupID = 5;
            string groupName;
            StudentGroup group;

            Console.WriteLine("Enter a group name (20 chars)...");
            groupName = Console.ReadLine();

            group = new StudentGroup(groupID, groupName);
            groups.Add(group);
            StorageAdapter.AddGroup(group);

        }

        public void EditGroup(int groupID)
        {
            string name;
            StudentGroup group = GetStudentGroup(groupID);

            Console.WriteLine("Enter a new group name (20 chars)...");
            name = Console.ReadLine();

            group.GroupName = name;
            StorageAdapter.EditGroup(group);
        }
    }
}
