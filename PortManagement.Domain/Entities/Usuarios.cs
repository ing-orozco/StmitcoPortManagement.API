﻿namespace PortManagement.Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        public ICollection<Operaciones> Operaciones { get; set; } = new List<Operaciones>();
    }

}
