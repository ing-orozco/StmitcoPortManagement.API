using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManagement.Domain.Entities
{
    public class Buques
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Bandera { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string Estado { get; set; } = string.Empty;

        public ICollection<Cargas> Cargas { get; set; } = new List<Cargas>();

        public ICollection<Operaciones> Operaciones { get; set; } = new List<Operaciones>();
    }

}
