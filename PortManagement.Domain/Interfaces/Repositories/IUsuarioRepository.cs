using PortManagement.Domain.Entities;
using System.Threading.Tasks;

namespace PortManagement.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuarios?> GetByEmailAndPasswordAsync(string email, string password);
        Task<Usuarios?> GetByEmailAsync(string email);
        Task AddAsync(Usuarios usuario);
    }
}
