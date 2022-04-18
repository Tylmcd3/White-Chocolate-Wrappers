using System;
namespace KIT206
{
    public class Meeting
    {
        //Private Fields
        private int _meetingID;
        private int _groupID;
        private Day _day;
        private DateTime _start;
        private DateTime _end;
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
        /*
            Constructor
            Need to check validity of the room, check that start appears before end 
            and that it isint longer than x time
        */
        public Meeting(int group_id, Day day, DateTime start, DateTime end, string room){
            MeetingID = GenerateMeetingID();
            GroupID = group_id;
            Day = day;
            Start = start;
            End = end;
            Room = room;
        }
        //Used for creating an object from Database
        public Meeting(int meeting_id, int group_id, Day day, DateTime start, DateTime end, string room){
            MeetingID = meeting_id;
            GroupID = group_id;
            Day = day;
            Start = start;
            End = end;
            Room = room;
        }
        private int GenerateMeetingID()
        {
            int id;
            do
            {
                id = (int)(DateTime.Now.Ticks % 1000000);
            } while (false);
            return id;
        }
        //Needs to be fixed
        //private bool Check_ID(int id)
        //{
        //    Meeting Meeting = null;

        //    foreach (Meeting meeting in StorageAdapter.Meetings)
        //    {
        //        if (meeting.MeetingID == id)
        //            Meeting = meeting;
        //    }
        //    return Meeting is Meeting;
        //}


        //Think need to move these to controller class?

        
        public void EditMeeting(){

            //StorageAdapter.EditMeeting(this);

        }
        //Removes meeting object
        public void CancelMeeting(){
            
            //StorageAdapter.Meetings.Remove(this);
        }
            
        public override string ToString()
        {
            return "The Meeting for the group " + " is on " + Day.ToString() + " at " + Start.ToString();
        }
    }
    
}