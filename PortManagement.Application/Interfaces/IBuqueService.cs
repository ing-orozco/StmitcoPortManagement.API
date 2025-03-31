using PortManagement.Domain.Entities;

namespace PortManagement.Application.Interfaces
{
    public interface IBuqueService
    {
        Task<IEnumerable<Buques>> GetAllAsync();
        Task<Buques> GetByIdAsync(int id);
        Task AddAsync(Buques buque);
        Task UpdateAsync(Buques buque);
        Task DeleteAsync(int id);
    }
}
