namespace KIT206
{
    public class Meeting
    {
        public int Meeting_ID{ get; set; }
        public int Group_ID { get; private set; }
        Day day { get; set; }
        DateTime start { get; set; }
        DateTime end { get; set; }
        string room { get; set; }
        
        public void SetMeetingID(int id){
            Meeting_ID = id;
        }
    }
    
}