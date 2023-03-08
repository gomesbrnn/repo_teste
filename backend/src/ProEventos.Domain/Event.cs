using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime? Date { get; set; }
        public string Theme { get; set; }
        public int AmountPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
        public bool Status { get; set; }

        public Event()
        {
            Status = true;
        }
    }
}