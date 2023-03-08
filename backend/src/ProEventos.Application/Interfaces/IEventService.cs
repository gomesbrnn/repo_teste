using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Interfaces
{
    public interface IEventService
    {
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
        Task<Event> AddEvent(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<Event> DeleteEvent(int eventId);
    }
}