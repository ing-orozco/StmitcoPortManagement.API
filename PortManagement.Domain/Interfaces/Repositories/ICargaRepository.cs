using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortManagement.Domain.Entities;

namespace PortManagement.Domain.Interfaces.Repositories
{
    public interface ICargaRepository
    {
        Task<IEnumerable<Cargas>> GetAllAsync();
        Task<Cargas?> GetByIdAsync(int id);
        Task AddAsync(Cargas carga);
        Task UpdateAsync(Cargas carga);
        Task DeleteAsync(int id);
    }
}
