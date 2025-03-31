using Microsoft.EntityFrameworkCore;
using PortManagement.Domain.Entities;
using PortManagement.Domain.Interfaces;
using PortManagement.Domain.Interfaces.Repositories;
using PortManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace PortManagement.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PortDbContext _context;

        public UsuarioRepository(PortDbContext context)
        {
            _context = context;
        }

        public async Task<Usuarios?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<Usuarios?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
