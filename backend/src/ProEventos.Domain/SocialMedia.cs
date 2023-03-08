namespace ProEventos.Domain.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public bool Status { get; set; }

        public SocialMedia()
        {
            Status = true;
        }
    }
}