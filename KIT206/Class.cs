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