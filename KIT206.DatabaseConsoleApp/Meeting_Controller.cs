using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.DatabaseApp
{
    class Meeting_Controller
    {
        private List<Meeting> meetings;
        public List<Meeting> Meetings { get { return meetings; } set { } }
        public Meeting_Controller(int id)
        {
            meetings = new List<Meeting>();
            meetings = StorageAdapter.GetMeetings(id);
        }

        public void ListMeetings()
        {
            foreach (Meeting meeting in meetings)
            {
                Console.WriteLine(meeting.ToString());
            }
        }

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

        public void AddMeeting(int meetingID, int groupID, Day day, TimeSpan start, TimeSpan end, string room)
        {
            Meeting meeting = new Meeting(meetingID, groupID, day, start, end, room);
            meetings.Add(meeting);
            //Update database
            StorageAdapter.AddMeeting(meeting);
        }

        public void EditMeeting(int id, Day day)
        {
            Meeting meeting = FindMeeting(id);
            meeting.Day = day;
            Console.WriteLine("edited meeting " + meeting.Day.ToString());
            //update database
            StorageAdapter.EditMeeting(meeting);
        }
        public void EditMeeting(int id, Day day, TimeSpan start, TimeSpan end)
        {
            Meeting meeting = FindMeeting(id);
            meeting.Day = day;
            meeting.Start = start;
            meeting.End = end;
            //Update database
            StorageAdapter.EditMeeting(meeting);
        }

        public void CancelMeeting(int id)
        {
            Meeting meeting = FindMeeting(id);
            meetings.Remove(meeting);
            //Update database
            StorageAdapter.RemoveMeeting(id);
        }

    }
}
