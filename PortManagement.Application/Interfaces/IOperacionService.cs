using PortManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Application.Interfaces
{
    public interface IOperacionService
    {
        Task<IEnumerable<Operaciones>> GetAllAsync();
        Task<Operaciones?> GetByIdAsync(int id);
        Task AddAsync(Operaciones operacion);
        Task UpdateAsync(Operaciones operacion);
        Task DeleteAsync(int id);
    }
}
