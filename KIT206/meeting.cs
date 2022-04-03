using System;
namespace KIT206
{
    public class Meeting
	{
		public int Meeting_ID { get; set; }
		public int Group_ID { get; private set; }
		Day Day { get; set; }
		DateTime start { get; set; }
		DateTime end { get; set; }
		string room { get; set; }

		public Meeting()
		{
			throw new System.NotImplementedException();
		}

		public StudentGroup StudentGroup
		{
			get => default;
			set
			{
			}
		}

		public void SetMeetingID(int id){
            Meeting_ID = id;
        }

		public void EditMeeting()
		{
			throw new System.NotImplementedException();
		}

		public void CancelMeeting()
		{
			throw new System.NotImplementedException();
		}
	}
    
}