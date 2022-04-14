using System;
using System.Collections.Generic;

namespace KIT206
{
    public class StudentGroup
	{
		//Private Fields
		private int _groupID;
		private string _groupName;


		//Public properties
		public int GroupID
        {
			get
			{
				return _groupID;
			}
			set
            {
				_groupID = value;
            }
        }
		public string GroupName
        {
			get
			{
				return _groupName;
			}
            set
            {
				_groupName = value;
            }
        }
		//either generates a number and checks it doesnt exists or find the next sequential one
		public StudentGroup(string name)
		{
			//Generate group ID and then set to groupID (5 is placeholder)

			_groupID = GenerateGroupID();
			_groupName = name;
		}
		public StudentGroup(string name, int id)
		{
			//Generate group ID and then set to groupID (5 is placeholder)

			_groupID = id;
			_groupName = name;
		}
		private int GenerateGroupID()
        {
			int id;
			do
			{
				id = (int)(DateTime.Now.Ticks % 1000000);
			} while (Check_ID(id));
			return id;
        }
		private bool Check_ID(int id)
		{
			StudentGroup studentGroup = null;

			foreach (StudentGroup group in Storage.Groups)
			{
				if (group._groupID == id)
					studentGroup = group;
			}
			return studentGroup is StudentGroup;
		}
		//Creation of a class
		public Class AddClass()
		{
			string StartTime, EndTime, Room;
			DateTime Start, End;
			Day day;



			Console.WriteLine("Enter the Start time of the Class in 24HR time (HH:MM dd/mm/yyyy):  ");
			StartTime = Console.ReadLine();

			Console.WriteLine("Enter the End time of the Class (HH:MM dd/mm/yyyy):  ");
			EndTime = Console.ReadLine();

			Console.WriteLine("Enter the Room Code");
			Room = Console.ReadLine();
			Start = DateTime.Parse(StartTime);
			End = DateTime.Parse(StartTime);
			day = (Day)Enum.ToObject(typeof(Day), (int)Start.DayOfWeek);


			return new Class(GroupID, day, Start, End, Room);
		}
		//Adding an already stored class
		public Class AddClass(int class_id)
		{
			string StartTime, EndTime, Room;
			DateTime Start, End;
			Day day;



			Console.WriteLine("Enter the Start time of the Class in 24HR time (HH:MM dd/mm/yyyy):  ");
			StartTime = Console.ReadLine();

			Console.WriteLine("Enter the End time of the Class (HH:MM dd/mm/yyyy):  ");
			EndTime = Console.ReadLine();

			Console.WriteLine("Enter the Room Code");
			Room = Console.ReadLine();
			Start = DateTime.Parse(StartTime);
			End = DateTime.Parse(StartTime);
			day = (Day)Enum.ToObject(typeof(Day), (int)Start.DayOfWeek);


			return new Class(class_id, GroupID, day, Start, End, Room);
		}

		public Meeting AddMeeting()
		{
			string StartTime, EndTime, Room;
			DateTime Start, End;
			Day day;



			Console.WriteLine("Enter the Start time of the meeting in 24HR time (HH:MM dd/mm/yyyy):  ");
			StartTime = Console.ReadLine();

			Console.WriteLine("Enter the End time of the meeting (HH:MM dd/mm/yyyy):  ");
			EndTime = Console.ReadLine();

			Console.WriteLine("Enter the Room Code");
			Room = Console.ReadLine();
			Start = DateTime.Parse(StartTime);
            End = DateTime.Parse(StartTime);
			day = (Day)Enum.ToObject(typeof(Day),(int) Start.DayOfWeek);


			return new Meeting(GroupID, day, Start, End, Room);
		}

		public void EditGroup()
		{
			throw new System.NotImplementedException();
		}
		//Two Overrides here, one for finding a group from a student and one for finding a group from an ID, Might just remove the top and take the id from the student
		public static StudentGroup GetGroup(Student student, List<StudentGroup> groups)
        {
			int id = student.StudentGroup;

			foreach(StudentGroup group in groups)
            {
				if(group.GroupID == id)
                {
					return group;
                }
            }
				return null;

		}
		public static StudentGroup GetGroup(int id, List<StudentGroup> groups)
		{
			foreach (StudentGroup group in groups)
			{
				if (group.GroupID == id)
				{
					return group;
				}
			}
			return null;

		}

		public override string ToString()
        {
			return (GroupName + "'s ID is " + GroupID);
        }
	}
}