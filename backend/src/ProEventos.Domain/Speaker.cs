using System.Collections.Generic;

namespace ProEventos.Domain.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonalResume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
        public bool Status { get; set; }

        public Speaker()
        {
            Status = true;
        }
    }
}