using Microsoft.EntityFrameworkCore;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;
using PortManagement.Infrastructure.Data;

namespace PortManagement.Infrastructure.Repositories
{
    public class CargaRepository : ICargaRepository
    {
        private readonly PortDbContext _context;

        public CargaRepository(PortDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargas>> GetAllAsync()
        {
            return await _context.Cargas.Include(c => c.Buque).ToListAsync();
        }

        public async Task<Cargas?> GetByIdAsync(int id)
        {
            return await _context.Cargas.Include(c => c.Buque).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cargas carga)
        {
            _context.ChangeTracker.Clear();
            await _context.Cargas.AddAsync(carga);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cargas carga)
        {
            _context.ChangeTracker.Clear();
            _context.Cargas.Update(carga);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carga = await _context.Cargas.FindAsync(id);
            if (carga != null)
            {
                _context.Cargas.Remove(carga);
                await _context.SaveChangesAsync();
            }
        }
    }
}
