using System;
namespace MySQL
{
	public class Class
	{
		private int _classID;
		private int _groupID;
		private Day _day;
		private DateTime _start;
		private DateTime _end;
		private string _room;

		public int ClassID
        {
			get => _classID;
			set
            {
				_classID = value;
            }
        }
		public int GroupID
		{
			get => _groupID;
			set
			{
				_groupID = value;
			}
		}
		public Day Day
        {
			get => _day;
			set
            {
				_day = value;
            }
        }
		public DateTime Start
        {
			get => _start;
			set
            {
				_start = value;
            }
        }
		public DateTime End
        {
			get => _end;
			set
            {
				_end = value;
            }
        }
		public string Room
        {
			get => _room;
			set
            {
				_room = value;
            }
        }
		public int Group_ID
		{
			get => _groupID;
		}
		//Overloading Constructors so we can either generate a new id for a new class or
		public Class(int groupID, Day day, DateTime start, DateTime end, string room)
		{
			//Generate classid and set here (5 is placeholder)
			_classID = GenerateGroupID();
			_groupID = groupID;
			_day = day;
			_start = start;
			_end = end;
			_room = room;
		}
		//We can get a class from the database and create a new object from that
		public Class(int classID,int groupID, Day day, DateTime start, DateTime end, string room)
		{
			//Generate classid and set here (5 is placeholder)
			_classID = classID;
			_groupID = groupID;
			_day = day;
			_start = start;
			_end = end;
			_room = room;
		}
		//Generates an ID from the time and then makes it a 6 digit number and then checks if an object has that id
		private int GenerateGroupID()
		{
			int id;
			do
			{
				id = (int)(DateTime.Now.Ticks % 1000000);
			} while (false);
			return id;
		}
		//Checking ID's, could potentially be made generic if we use Type of and passed a type of something?
		//Need to do more research but this will do for now
		//Cant have this list access here
		//private bool Check_ID(int id)
		//{
		//	Class Class = null;

		//	foreach (Class _class in StorageAdapter.Classes)
		//	{
		//		if (_class._classID == id)
		//			Class = _class;
		//	}
		//	return Class is Class;
		//}

        public override string ToString()
        {
			return "The Class for the group "  + " is on every " + Day.ToString() + " at " + Start.ToString("hh:mm tt");
		}

    }
}