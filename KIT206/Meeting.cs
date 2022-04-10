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
            get => default;
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

        }

        //Think need to move these to controller class?

        //Overloaded function to edit the day and time of the meeting.
        //changes depending on if they pass in the day, times or both.
        public void EditMeeting(Day day){
            _day = day;
        }
        public void EditMeeting(DateTime start, DateTime end){
            _start = start;
            _end = end;
        }
        public void EditMeeting(Day day, DateTime start, DateTime end){
            EditMeeting(day);
            EditMeeting(start, end);
        }
        //Removes meeting object
        public void CancelMeeting(){
            
        }
    }
    
}