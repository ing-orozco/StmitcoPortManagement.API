using System.Threading.Tasks;
using PortManagement.Domain.Entities;

namespace PortManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse?> AuthenticateAsync(string email, string password);
   
    }
}
