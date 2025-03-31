using PortManagement.Application.Interfaces;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;

namespace PortManagement.Application.Services
{
    public class BuqueService : IBuqueService
    {
        private readonly IBuqueRepository _buqueRepository;

        public BuqueService(IBuqueRepository buqueRepository)
        {
            _buqueRepository = buqueRepository;
        }

        public async Task<IEnumerable<Buques>> GetAllAsync()
        {
            return await _buqueRepository.GetAllAsync();
        }

        public async Task<Buques> GetByIdAsync(int id)
        {
            return await _buqueRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Buques buque)
        {
            await _buqueRepository.AddAsync(buque);
        }

        public async Task UpdateAsync(Buques buque)
        {
            await _buqueRepository.UpdateAsync(buque);
        }

        public async Task DeleteAsync(int id)
        {
            await _buqueRepository.DeleteAsync(id);
        }
    }
}
