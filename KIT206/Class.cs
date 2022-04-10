using System;
namespace KIT206
{
	public class Class
	{
		private int _classID;
		private int _groupID;
		private Day _date;
		private DateTime _start;
		private DateTime _end;
		private string _room;

		public int ClassID
        {
			get => default;
			set
            {
				_classID = value;
            }
        }
		public Day Date
        {
			get => default;
			set
            {
				_date = value;
            }
        }
		public DateTime Start
        {
			get => default;
			set
            {
				_start = value;
            }
        }
		public DateTime End
        {
			get => default;
			set
            {
				_end = value;
            }
        }
		public string Room
        {
			get => default;
			set
            {
				_room = value;
            }
        }

		public Class(int groupID, Day day, DateTime start, DateTime end, string room)
		{
			//Generate classid and set here (5 is placeholder)
			_classID = 5;
			_groupID = groupID;
			_date = day;
			_start = start;
			_end = end;
			_room = room;
		}

		public StudentGroup StudentGroup
		{
			get => default;
			set
			{
			}
		}
	}
}