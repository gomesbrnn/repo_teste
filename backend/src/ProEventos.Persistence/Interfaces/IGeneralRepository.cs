using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces
{
    public interface IGeneralRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();
    }
}