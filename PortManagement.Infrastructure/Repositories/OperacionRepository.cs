using Azure;
using Microsoft.EntityFrameworkCore;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces.Repositories;
using PortManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortManagement.Infrastructure.Repositories
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly PortDbContext _context;

        public OperacionRepository(PortDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Operaciones>> GetAllAsync()
        {
            return await _context.Operaciones.ToListAsync();
        }

        public async Task<Operaciones?> GetByIdAsync(int id)
        {
            return await _context.Operaciones.FindAsync(id);
        }

        public async Task AddAsync(Operaciones operacion)
        {
            _context.ChangeTracker.Clear();
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Operaciones operacion)
        {
            _context.ChangeTracker.Clear();
            _context.Operaciones.Update(operacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion != null)
            {
                _context.Operaciones.Remove(operacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
