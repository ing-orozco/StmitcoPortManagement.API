using PortManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Domain.Interfaces.Repositories
{
    public interface IBuqueRepository
    {
        Task<IEnumerable<Buques>> GetAllAsync();
        Task<Buques> GetByIdAsync(int id);
        Task AddAsync(Buques buque);
        Task UpdateAsync(Buques buque);
        Task DeleteAsync(int id);
    }
}
