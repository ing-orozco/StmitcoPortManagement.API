using PortManagement.Application.Interfaces;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;

namespace PortManagement.Application.Services
{
    public class CargaService : ICargaService
    {
        private readonly ICargaRepository _cargaRepository;

        public CargaService(ICargaRepository cargaRepository)
        {
            _cargaRepository = cargaRepository;
        }

        public async Task<IEnumerable<Cargas>> GetAllAsync()
        {
            return await _cargaRepository.GetAllAsync();
        }

        public async Task<Cargas?> GetByIdAsync(int id)
        {
            return await _cargaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Cargas carga)
        {
            await _cargaRepository.AddAsync(carga);
        }

        public async Task UpdateAsync(Cargas carga)
        {
            await _cargaRepository.UpdateAsync(carga);
        }

        public async Task DeleteAsync(int id)
        {
            await _cargaRepository.DeleteAsync(id);
        }
    }
}
