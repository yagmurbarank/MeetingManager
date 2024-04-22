namespace MeetingManager.Models
{
    public class AddMeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

    }
}
