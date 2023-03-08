using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false);
        Task<Speaker> DeleteSpeakerById(int speakerId);
    }
}