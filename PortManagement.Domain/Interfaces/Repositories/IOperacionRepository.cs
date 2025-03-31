using PortManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Domain.Interfaces.Repositories
{
    public interface IOperacionRepository
    {
        Task<IEnumerable<Operaciones>> GetAllAsync();
        Task<Operaciones?> GetByIdAsync(int id);
        Task AddAsync(Operaciones operacion);
        Task UpdateAsync(Operaciones operacion);
        Task DeleteAsync(int id);
    }
}
