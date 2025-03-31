using Microsoft.EntityFrameworkCore;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;
using PortManagement.Infrastructure.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Infrastructure.Repositories
{
    public class BuqueRepository : IBuqueRepository
    {
        private readonly PortDbContext _context;

        public BuqueRepository(PortDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Buques>> GetAllAsync()
        {
            return await _context.Buques.ToListAsync();
        }

        public async Task<Buques> GetByIdAsync(int id)
        {
            return await _context.Buques.FindAsync(id);
        }

        public async Task AddAsync(Buques buque)
        {
            _context.ChangeTracker.Clear();
            await _context.Buques.AddAsync(buque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Buques buque)
        {
            _context.ChangeTracker.Clear();
            _context.Buques.Update(buque);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var buque = await _context.Buques.FindAsync(id);
            if (buque != null)
            {
                _context.Buques.Remove(buque);
                await _context.SaveChangesAsync();
            }
        }
    }
}
