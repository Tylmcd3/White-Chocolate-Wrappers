using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    public class Meeting_Controller
    {
        protected List<Meeting> meetings;
        public List<Meeting> Meetings { get { return meetings; } set { } }
        public Meeting_Controller(int id)
        {
            meetings = new List<Meeting>();
            meetings = StorageAdapter.LoadMeetings(id);
        }
        ///<summary>
        ///Prints list of Meetings to Console
        ///</summary>
        public List<string> ListMeetings()
        {
            List<string> toReturn = new List<string>();
            foreach (Meeting meeting in meetings)
            {
                toReturn.Add(meeting.ToString());
            }
            return toReturn;
        }
        ///<summary>
        ///Finds Meeting given an ID
        ///</summary>
        public Meeting FindMeeting(int id)
        {
            foreach (Meeting meeting in meetings)
            {
                if (meeting.MeetingID == id)
                {
                    return meeting;
                }
            }
            return null;
        }

        //TODO generate ID rather than calling in param
        ///<summary>
        ///Creates new Meeting and adds to database
        ///</summary>
        public void AddMeeting(int groupID, Day day, TimeSpan start, TimeSpan end, string room)
        {
            int meetingID = GenerateID();

            Meeting meeting = new Meeting(meetingID, groupID, day, start, end, room);
            meetings.Add(meeting);
            //Update database
            StorageAdapter.AddMeeting(meeting);
        }
        ///<summary>
        ///Edits Meeting Day
        ///</summary>
        public void EditMeeting(int id, Day day)
        {
            Meeting meeting = FindMeeting(id);
            meeting.Day = day;
            Console.WriteLine("edited meeting " + meeting.Day.ToString());
            //update database
            StorageAdapter.EditMeeting(meeting);
        }
        ///<summary>
        ///Edits Meeting start and end time
        ///</summary>
        public void EditMeeting(int id, TimeSpan start, TimeSpan end)
        {
            Meeting meeting = FindMeeting(id);
            meeting.Start = start;
            meeting.End = end;
            //Update database
            StorageAdapter.EditMeeting(meeting);
        }
        ///<summary>
        ///Edits Meeting Day, and start/end time.
        ///</summary>
        public void EditMeeting(int id, Day day, TimeSpan start, TimeSpan end)
        {
            Meeting meeting = FindMeeting(id);
            meeting.Day = day;
            meeting.Start = start;
            meeting.End = end;
            //Update database
            StorageAdapter.EditMeeting(meeting);
        }
        ///<summary>
        ///Removes Meeting from database
        ///</summary>
        public void CancelMeeting(int id)
        {
            Meeting meeting = FindMeeting(id);
            meetings.Remove(meeting);
            //Update database
            StorageAdapter.RemoveMeeting(id);
        }
        ///<summary>
        ///Generates Meeting ID iteratively
        ///</summary>
        public int GenerateID()
        {
            int highest = 0;

            List<Meeting> allMeetings = StorageAdapter.LoadMeetings();

            foreach (Meeting meeting in allMeetings)
            {
                if (highest <= meeting.MeetingID)
                {
                    highest = meeting.MeetingID;
                }
            }
            return ++highest;
        }

    }
}
