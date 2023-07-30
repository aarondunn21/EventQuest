namespace EventQuest.Models
{
    public class TicketmasterResponse
    {
        public Embedded _embedded { get; set; }
    }

    public class Embedded
    {
        public Event[] events { get; set; }
    }

    public class Event
    {
        public string name { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public Dates dates { get; set; }
        public EmbeddedVenue _embedded { get; set; }
        public Images[] images { get; set; }
    }

    public class Dates
    {
        public Start start { get; set; }
    }

    public class Start
    {
        public string localDate { get; set; }
        public string localTime { get; set; }
    }

    public class EmbeddedVenue
    {
        public Venue[] venues { get; set; }
    }

    public class Venue
    {
        public string name { get; set; }
    }

/*    public class EmbeddedImage
    {
        public Image[] images { get; set; }
    }
*/
    public class Images
    {
        public string url { get; set; }
        public int width { get; set; }
    }

}
