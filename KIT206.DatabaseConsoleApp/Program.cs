using System;
using System.Collections.Generic;
using System.Globalization;

namespace KIT206.DatabaseApp
{
    class Program
    {
        //Driver Class
        public static void Main(string[] args)
        {
            Student student;
            Student_Controller controller = new Student_Controller();
            StudentGroup_Controller group_Controller = new();

            foreach(Student item in controller.Students)
            {
                Console.WriteLine(item.ToString(""));
            }

            Boolean success;
            int option = -1;
            int studentID;
            Console.WriteLine("Enter your student ID...\n");
            studentID = int.Parse(Console.ReadLine());

            controller.SelectStudent(studentID);
            student = controller.CurrentStudent;
            if(student.StudentGroup != -1)
            {
                group_Controller.SelectGroup(student.StudentGroup);
            }
            Console.WriteLine("Welcome, " + student.FirstName);



            while(option != 0)
            {
                option = -1;

                Console.WriteLine("Make a selection\n" +
                                "[0] Exit\n" +
                                "[1] Personal Data Menu\n" +
                                "[2] Group Menu\n" +
                                "[3] View upcoming meetings and classes");

                success = int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;

                    case 1:

                        while(option != 0)
                        {
                            Console.WriteLine("Make a selection\n" +
                                            "[0] Exit\n" +
                                            "[1] View Personal data\n" +
                                            "[2] Edit Personal data\n");
                            success = int.TryParse(Console.ReadLine(), out option);

                            switch (option)
                            {
                                case 0:
                                    Console.WriteLine("Bye bye");
                                    break;
                                case 1:
                                    //view data
                                    Console.WriteLine($"{student.Title} {student.FirstName} {student.LastName} | {student.StudentID}\n");
                                    Console.WriteLine($"Phone: {student.Phone}\n");
                                    Console.WriteLine($"Email: {student.Email}\n");
                                    Console.WriteLine($"Campus: {student.Campus.ToString()}\n");
                                    Console.WriteLine($"Category: {student.Category.ToString()}\n");
                                    break;
                                case 2:
                                    //edit data
                                    string title, phone, email;
                                    Category category;
                                    Campus campus;
                                    Console.WriteLine("Enter your title (Mr./Mrs./Ms./Dr.)...");
                                    title = Console.ReadLine();
                                    Console.WriteLine("Are you completing a Bachelors or a Masters? ([1] for Bachelors, [2] for Masters)...");
                                    category = int.Parse(Console.ReadLine()) == 1 ? Category.Bachelors : Category.Masters;
                                    Console.WriteLine("Where do you study? ([1] for Hobart, [2] for Launceston)...");
                                    campus = int.Parse(Console.ReadLine()) == 1 ? Campus.Hobart : Campus.Launceston;
                                    Console.WriteLine("Enter your phone number");
                                    phone = Console.ReadLine();
                                    Console.WriteLine("Enter your email");
                                    email = Console.ReadLine();

                                    controller.AddStudentDetails(title, campus, email, category, phone);
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid option");
                                    break;
                            }
                        }
                        option = -1;
                        break;

                    case 2:
                        while(option != 0)
                        {
                            if (student.StudentGroup == -1)
                            {
                                Console.WriteLine("You are not currently in a group.\n" +
                                                "[0] Exit\n" +
                                                "[1] View Groups\n" +
                                                "[2] Join Group\n" +
                                                "[3] Create Group");
                                success = int.TryParse(Console.ReadLine(), out option);

                                switch (option)
                                {
                                    case 0:
                                        Console.WriteLine("Bye bye");
                                        break;
                                    case 1:
                                        foreach (StudentGroup group in group_Controller.Groups)
                                        {
                                            Console.WriteLine(group.ToString());
                                        }
                                        break;
                                    case 2:
                                        int groupToJoin;
                                        Console.WriteLine("Enter a group ID to join");
                                        success = int.TryParse(Console.ReadLine(), out groupToJoin);
                                        controller.EditStudentGroupMembership(groupToJoin);
                                        break;
                                    case 3:
                                        string groupName;
                                        Console.WriteLine("Enter a group name");
                                        groupName = Console.ReadLine();
                                        group_Controller.AddGroup(groupName);
                                        controller.EditStudentGroupMembership(1);
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid option");
                                        break;
                                }
                            }
                            //TODO add add meetings and class
                            else
                            {
                                Console.WriteLine($"You are in group {group_Controller.FindStudentGroup(student.StudentGroup).GroupName} ({student.StudentGroup}).\n" +
                                                "[0] Exit\n" +
                                                "[1] View Groups\n" +
                                                "[2] Join Group\n" +
                                                "[3] Create Group");
                                success = int.TryParse(Console.ReadLine(), out option);
                            }
                        }
                        option = -1;
                        break;

                    case 3:
                        Console.WriteLine(student.StudentGroup);
                        if(student.StudentGroup != -1)
                        {
                            Console.WriteLine("Meetings: \n");
                            group_Controller.Group_Meetings.ListMeetings();
                            Console.WriteLine("Class: \n");
                            group_Controller.Group_Class.GroupClass.ToString();
                        }
                        break;

                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }
            }



            //int ID = 1;


            //Student user = StorageAdapter.GetStudent(ID);
            //int MainSelection = 1;
            //int PersonalSelection = 1;
            //int GroupSelection = 1;
            //int MeetingSelection = 1;
            //bool Success = false;
            //while (MainSelection != 0)
            //{
            //    while (!Success)
            //    {
            //        Console.WriteLine("Make a selection\n1.Personal Data Menu\n2.Group Menu\n3.View Upcomming meetings and classes\n0.Quit\n");
            //        Success = int.TryParse(Console.ReadLine(), out MainSelection);
            //        if (!Success || MainSelection >= 4)
            //        {
            //            Console.WriteLine("That wasnt a valid input, try again");
            //            Success = false;
            //        }

            //    }
            //    Success = false;
            //    switch (MainSelection)
            //    {
            //        case 1://Personal Data Menu Finished
            //            PersonalSelection = 1;
            //            while (PersonalSelection != 0)
            //            {
            //                while (!Success)
            //                {
            //                    Console.WriteLine("Make a selection\n1.View Personal Data\n2.Add Personal Data\n0.Quit\n");
            //                    Success = int.TryParse(Console.ReadLine(), out PersonalSelection);
            //                    if (!Success || PersonalSelection >= 3)
            //                    {
            //                        Console.WriteLine("That wasnt a valid input, try again");
            //                        Success = false;
            //                    }

            //                }
            //                Success = false;
            //                switch (PersonalSelection)
            //                {
            //                    case 1://View Personal Data
            //                        Console.WriteLine(user.ToString("full"));
            //                        break;

            //                    case 2://Add Personal Data
            //                        if (user.Email == null)
            //                        {
            //                            string title;
            //                            int enumInt = -1;
            //                            Campus campus;
            //                            Category category;
            //                            string Email;
            //                            string Phone;
            //                            Console.WriteLine("Enter your Title: ");
            //                            title = Console.ReadLine();

            //                            while (enumInt == -1 && enumInt <= 2)
            //                            {
            //                                Console.WriteLine("Enter your Campus, for Hobart enter 1 and for Launceston enter 2: ");
            //                                try
            //                                {
            //                                    enumInt = Convert.ToInt32(Console.ReadLine()) - 1;
            //                                }
            //                                catch
            //                                {
            //                                    Console.WriteLine("Try Again");
            //                                }

            //                            }
            //                            campus = (Campus)enumInt;
            //                            enumInt = -1;
            //                            Console.WriteLine("Enter your Email: ");
            //                            Email = Console.ReadLine();

            //                            while (enumInt == -1 && enumInt <= 2)
            //                            {
            //                                Console.WriteLine("Enter your Category of study, for Batchelors enter 1 and for Masters enter 2: ");
            //                                try
            //                                {
            //                                    enumInt = Convert.ToInt32(Console.ReadLine()) - 1;
            //                                }
            //                                catch
            //                                {
            //                                    Console.WriteLine("Try Again");
            //                                }

            //                            }
            //                            category = (Category)enumInt;

            //                            Console.WriteLine("Enter your phone number: ");
            //                            Phone = Console.ReadLine();
            //                            //user.AddStudentDetails(title, campus, category, Email, Phone);


            //                        }
            //                        else
            //                        {
            //                            Console.WriteLine("You have already entered your details");
            //                        }
            //                        break;
            //                }
            //            }
            //            break;
            //        case 2://Group Menu
            //            GroupSelection = 1;
            //            while (GroupSelection != 0)
            //            {
            //                if (user.StudentGroup > 0)
            //                {
            //                    StudentGroup group = StorageAdapter.GetGroup(user.StudentGroup);
            //                    while (!Success)
            //                    {
            //                        Console.WriteLine("Make a selection\n1.Show Group Members\n2.Show Class\n3.Edit Group\n4.Meeting menu\n5.Leave Group\n0.Quit\n");
            //                        Success = int.TryParse(Console.ReadLine(), out GroupSelection);
            //                        if (!Success || GroupSelection >= 6)
            //                        {
            //                            Console.WriteLine("That wasnt a valid input, try again");
            //                            Success = false;
            //                        }
            //                    }
            //                    Success = false;
            //                    switch (GroupSelection)
            //                    {
            //                        case 1://Show Group Members
            //                            //List<Student> GroupMembers = group.GetGroupMembers(ID);
            //                            if (GroupMembers.Count > 0)
            //                            {
            //                                foreach (Student Member in GroupMembers)
            //                                {
            //                                    //Console.WriteLine(Member.GetStudentString());
            //                                }
            //                            }
            //                            else
            //                            {
            //                                Console.WriteLine("There are no members of your group");
            //                            }
            //                            break;
            //                        case 2://Show Class
            //                            Console.WriteLine(StorageAdapter.GetClass(group.GroupID).ToString());
            //                            break;
            //                        case 3://Edit group name
            //                            Console.WriteLine("Enter the new name for the group");
            //                            //group.EditGroup(Console.ReadLine());
            //                            break;
            //                        case 4://Meeting menu
            //                            while (MeetingSelection != 0)
            //                            {
            //                                while (!Success)
            //                                {
            //                                    Console.WriteLine("Make a selection\n1.View Meetings\n2.Create new Meeting\n3.Cancel Meeting\n4.Edit Meeting\n0.Quit\n");
            //                                    Success = int.TryParse(Console.ReadLine(), out MeetingSelection);
            //                                    if (!Success || PersonalSelection >= 5)
            //                                    {
            //                                        Console.WriteLine("That wasnt a valid input, try again");
            //                                        Success = false;
            //                                    }
            //                                }
            //                                Success = false;

            //                                switch (MeetingSelection)
            //                                {
            //                                    case 1://View Meetings

            //                                        //List<Meeting> Meetings = group.GetMeetings();
            //                                        Console.WriteLine("----Meeting------");
            //                                        foreach (Meeting meeting in Meetings)
            //                                        {
            //                                            Console.WriteLine(meeting.ToString());
            //                                        }
            //                                        break;
            //                                    case 2://Create New Meetings
            //                                        /StorageAdapter.AddMeeting(group.AddMeeting());
            //                                        break;
            //                                    case 3://Cancel Meeting needs to be fixed
            //                                        DateTime finder;

            //                                        Console.WriteLine("Enter the original Date for the meeting (hh:mm dd/mm/yyyy)");
            //                                        finder = DateTime.Parse(Console.ReadLine());

            //                                        StorageAdapter.GetMeeting(finder).CancelMeeting();
            //                                        break;
            //                                    //Date time parsing will crash if not typed in properly, could make a try catch thing but
            //                                    //as the UI will have a calendar and will always send the right thing i cant be bothered 
            //                                    case 4://Edit meetings this doesnt work either
            //                                        DateTime start, end, Identifier;
            //                                        Day day;
            //                                        Meeting meet;

            //                                        Console.WriteLine("Enter the original Date for the meeting (hh:mm dd/mm/yyyy)");
            //                                        Identifier = DateTime.Parse(Console.ReadLine());
            //                                        Console.WriteLine("Enter the new Start Date: HH:MM dd/mm/yyyy");
            //                                        start = DateTime.Parse(Console.ReadLine());
            //                                        Console.WriteLine("Enter the new end Date: HH:MM dd/mm/yyyy");
            //                                        end = DateTime.Parse(Console.ReadLine());
            //                                        day = (Day)Enum.ToObject(typeof(Day), (int)start.DayOfWeek);
            //                                        meet = StorageAdapter.GetMeeting(Identifier);
            //                                        meet.Start = start;
            //                                        meet.End = end;
            //                                        meet.Day = day;
            //                                        StorageAdapter.EditMeeting(meet);
            //                                        break;
            //                                }
            //                            }
            //                            break;
            //                        case 5://Leave Group
            //                            user = user.EditStudentGroup();
            //                            GroupSelection = 0;
            //                            break;
            //                    }
            //                }
            //                else
            //                {
            //                    Console.WriteLine("You dont have a group, would you like to add one now? (y,n)");
            //                    if (Console.ReadLine() == "y")
            //                    {
            //                        Console.WriteLine("Enter the name for your group: ");
            //                        string name = Console.ReadLine();
            //                        StudentGroup newGroup = user.AddGroup(name);


            //                        StorageAdapter.AddGroup(newGroup);
            //                        StorageAdapter.EditStudent(user);

            //                    }
            //                }
            //            }
            //            break;
            //        case 3://View Upcoming meetings and classes
            //            if (user.StudentGroup != 0)
            //            {
            //                StudentGroup UserGroup = StorageAdapter.GetGroup(user.StudentGroup);
            //                List<Meeting> meetings = UserGroup.GetMeetings();

            //                Console.WriteLine("-------Class-------");
            //                Console.WriteLine(StorageAdapter.GetClass(UserGroup.GroupID).ToString());
            //                if (meetings.Count >= 1)
            //                {
            //                    Console.WriteLine("----Meeting------");
            //                    foreach (Meeting meeting in meetings)
            //                    {
            //                        Console.WriteLine(meeting.ToString());
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("The user doesnt have a Group, Join a Group and try again");
            //            }
            //            break;
            //    }
            //}
        }
    }
}