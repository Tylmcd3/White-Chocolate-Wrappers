using System;
namespace KIT206
{
	public class Class
	{
		private int _classID;
		private int _groupID;
		private Day _day;
		private TimeSpan _start;
		private TimeSpan _end;
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
		public TimeSpan Start
        {
			get => _start;
			set
            {
				_start = value;
            }
        }
		public TimeSpan End
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
		///<summary>
		///Creates a new Class Object
		///</summary>
		public Class(int classID,int groupID, Day day, TimeSpan start, TimeSpan end, string room)
		{
			//Generate classid and set here (5 is placeholder)
			_classID = classID;
			_groupID = groupID;
			_day = day;
			_start = start;
			_end = end;
			_room = room;
		}

        public override string ToString()
        {
			return ($"{_day.ToString()} at {_start.ToString()} in room {_room.ToString()}");
		}

    }
}