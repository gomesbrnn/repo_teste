using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly AppDbContext _context;

        public SpeakerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                                 .Include(p => p.SocialMedia)
                                                                 .OrderBy(p => p.Id)
                                                                 .AsNoTracking();

            if (includeEvents is true)
            {
                query = query
                             .Include(p => p.SpeakersEvents)
                             .ThenInclude(pe => pe.Event);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                         .Include(p => p.SocialMedia)
                                                         .Where(p => p.Name.ToLower() == name.ToLower())
                                                         .OrderBy(p => p.Id)
                                                         .AsNoTracking();

            if (includeEvents is true)
            {
                query = query
                             .Include(p => p.SpeakersEvents)
                             .ThenInclude(pe => pe.Event);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                         .Include(p => p.SocialMedia)
                                                         .Where(p => p.Id == speakerId)
                                                         .OrderBy(p => p.Id)
                                                         .AsNoTracking();

            if (includeEvents is true)
            {
                query = query
                             .Include(p => p.SpeakersEvents)
                             .ThenInclude(pe => pe.Event);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Speaker> DeleteSpeakerById(int speakerId)
        {
            Speaker speaker = await _context.Speakers.FirstOrDefaultAsync(p => p.Id == speakerId);

            if (speaker is not null) speaker.Status = false;

            return speaker;
        }
    }
}