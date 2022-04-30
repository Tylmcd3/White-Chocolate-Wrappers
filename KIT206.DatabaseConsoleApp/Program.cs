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

            foreach (Student item in controller.Students)
            {
                Console.WriteLine(item.ToStringFull());
            }

            Boolean success;
            int option = -1;
            int studentID;
            Console.WriteLine("Enter your student ID...\n");
            studentID = int.Parse(Console.ReadLine());

            controller.SelectStudent(studentID);
            student = controller.CurrentStudent;
            if (student.StudentGroup != -1)
            {
                group_Controller.SelectGroup(student.StudentGroup);
            }
            Console.WriteLine("Welcome, " + student.FirstName);

            while (option != 0)
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

                        while (option != 0)
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
                        string defaultOptions = ("[0] Exit\n" +
                                                "[1] View Groups\n" +
                                                "[2] Join Group\n" +
                                                "[3] Create Group\n");
                        while (option != 0)
                        {
                            if (student.StudentGroup == -1)
                            {
                                Console.WriteLine("You are not currently in a group.\n" + defaultOptions);
                            }
                            else
                            {
                                Console.WriteLine($"You are in group {group_Controller.FindStudentGroup(student.StudentGroup).GroupName} (ID: {student.StudentGroup}).\n" +
                                    $"{defaultOptions}" +
                                    $"[4]Add Meeting\n" +
                                    $"[5]Edit Meeting\n" +
                                    $"[6]Add Class\n");
                            }
                            Console.WriteLine("[0] Exit\n" +
                                            "[1] View Groups\n" +
                                            "[2] Join Group\n" +
                                            "[3] Create Group\n");
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
                                case 4://Add meeting
                                    TimeSpan meetingStart, meetingEnd;
                                    Day meetingDay;
                                    string meetingRoom;
                                    Console.WriteLine("Enter a day for the meeting (Mon-Sun, [0]-[7])");
                                    meetingDay = (Day)(int.Parse(Console.ReadLine()));
                                    Console.WriteLine("Enter a start time for the meeting (hh:mm)");
                                    meetingStart = TimeSpan.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter an end time for the meeting (hh:mm)");
                                    meetingEnd = TimeSpan.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter a room for the meeting");
                                    meetingRoom = Console.ReadLine();
                                    group_Controller.Group_Meetings.AddMeeting(student.StudentGroup, meetingDay, meetingStart, meetingEnd, meetingRoom);
                                    break;
                                case 5://edit meeting
                                    int meetingId;
                                    group_Controller.Group_Meetings.ListMeetings();
                                    meetingId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Which meeting would you like to edit? (Enter ID)");
                                    Console.WriteLine("Do you want to edit the [0] day, or [1] time?");
                                    option = int.Parse(Console.ReadLine());
                                    if (option == 1)
                                    {
                                        Day editDay;
                                        Console.WriteLine("Enter a day for the meeting (Mon-Sun, [0]-[7])");
                                        editDay = (Day)(int.Parse(Console.ReadLine()));
                                        group_Controller.Group_Meetings.EditMeeting(meetingId, editDay);
                                    }
                                    else
                                    {
                                        TimeSpan editStart, editEnd;
                                        Console.WriteLine("Enter a start time for the meeting (hh:mm)");
                                        editStart = TimeSpan.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter an end time for the meeting (hh:mm)");
                                        editEnd = TimeSpan.Parse(Console.ReadLine());
                                        group_Controller.Group_Meetings.EditMeeting(meetingId, editStart, editEnd);
                                    }
                                    option = -1;
                                    break;
                                case 6://add class
                                    TimeSpan classStart, classEnd;
                                    Day classDay;
                                    string classRoom;
                                    Console.WriteLine("Enter a day for the class (Mon-Sun, [0]-[7])");
                                    classDay = (Day)(int.Parse(Console.ReadLine()));
                                    Console.WriteLine("Enter a start time for the class (hh:mm)");
                                    classStart = TimeSpan.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter an end time for the class (hh:mm)");
                                    classEnd = TimeSpan.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter a room for the meeting");
                                    classRoom = Console.ReadLine();
                                    group_Controller.Group_Class.AddClass(4, student.StudentGroup, classDay, classStart, classEnd, classRoom);
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid option");
                                    break;
                            }
                        }

                        //TODO add add meetings and class
                        option = -1;
                        break;

                    case 3:
                        Console.WriteLine(student.StudentGroup);
                        if (student.StudentGroup != -1)
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
        }
    }
}