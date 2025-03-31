using PortManagement.Domain.Entities;

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public Usuarios User { get; set; }
}
