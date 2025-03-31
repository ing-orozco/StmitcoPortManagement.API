using PortManagement.Application.Interfaces;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Application.Services
{
    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository;

        public OperacionService(IOperacionRepository operacionRepository)
        {
            _operacionRepository = operacionRepository;
        }

        public async Task<IEnumerable<Operaciones>> GetAllAsync()
        {
            return await _operacionRepository.GetAllAsync();
        }

        public async Task<Operaciones?> GetByIdAsync(int id)
        {
            return await _operacionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Operaciones operacion)
        {
            await _operacionRepository.AddAsync(operacion);
        }

        public async Task UpdateAsync(Operaciones operacion)
        {
            await _operacionRepository.UpdateAsync(operacion);
        }

        public async Task DeleteAsync(int id)
        {
            await _operacionRepository.DeleteAsync(id);
        }
    }
}
