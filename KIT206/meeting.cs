using System;
namespace KIT206
{
    public class Meeting
    {
        private int _meetingID;
        private int _groupID;
        private Day _day;
        private DateTime _start;
        private DateTime _end;
        private string _room;

        /*
            Constructor
            Need to check validity of the room, check that start appears before end 
            and that it isint longer than x time
        */
        public Meeting(int group_id, Day day, DateTime start, DateTime end, string room){

        }
        //Overloaded function to edit the day and time of the meeting.
        //changes depending on if they pass in the day, times or both.
        public static void EditMeeting(Day day){

        }
        public static void EditMeeting(DateTime start, DateTime end){

        }
        public static void EditMeeting(Day day, DateTime start, DateTime end){

        }
        //Removes meeting object
        public static void CancelMeeting(){

        }

        
    }
    
}