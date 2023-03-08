using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                                       .Include(e => e.Lots)
                                                       .Include(e => e.SocialMedia)
                                                       .Where(e => e.Status == true)
                                                       .OrderBy(e => e.Id)
                                                       .AsNoTracking();

            if (includeSpeakers is true)
            {
                query = query
                             .Include(e => e.SpeakersEvents)
                             .ThenInclude(pe => pe.Speaker);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                                        .Include(e => e.Lots)
                                                        .Include(e => e.SocialMedia)
                                                        .Where(e => e.Theme.ToLower() == theme.ToLower() && e.Status == true)
                                                        .OrderBy(e => e.Id)
                                                        .AsNoTracking();

            if (includeSpeakers is true)
            {
                query = query
                             .Include(e => e.SpeakersEvents)
                             .ThenInclude(pe => pe.Speaker);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                                        .Include(e => e.Lots)
                                                        .Include(e => e.SocialMedia)
                                                        .Where(e => e.Id == eventId && e.Status == true)
                                                        .OrderBy(e => e.Id)
                                                        .AsNoTracking();

            if (includeSpeakers is true)
            {
                query = query
                             .Include(e => e.SpeakersEvents)
                             .ThenInclude(pe => pe.Speaker);
            }

            return await query.FirstAsync();
        }

        public async Task<Event> DeleteEventById(int eventId, bool includeSpeakers = false)
        {
            Event eventQuery = await _context.Events.FirstAsync(e => e.Id == eventId);

            if (eventQuery is null) return null;

            eventQuery.Status = false;

            return eventQuery;
        }
    }
}