using System;

namespace KIT206
{
    public class Meeting
    {
        //Private Fields
        private int _meetingID;
        private int _groupID;
        private Day _day;
        private TimeSpan _start;
        private TimeSpan _end;
        private string _room;


        //Public Properties
        public int MeetingID
        {
            get => _meetingID;
            set
            {
                _meetingID = value;
            }
        }

        public int GroupID
        {
            get =>_groupID;
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
        ///Creates a new Meeting object
        ///</summary>
        public Meeting(int meeting_id, int group_id, Day day, TimeSpan start, TimeSpan end, string room){
            MeetingID = meeting_id;
            GroupID = group_id;
            Day = day;
            Start = start;
            End = end;
            Room = room;
        }

        public override string ToString()
        {
            return ($"{_day.ToString()} at {_start.ToString()} in room {_room.ToString()}");
        }
    }
    
}