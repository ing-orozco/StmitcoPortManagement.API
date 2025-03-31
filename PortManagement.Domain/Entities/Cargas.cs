using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManagement.Domain.Entities
{
    public class Cargas
    {
        public int Id { get; set; }
        public string TipoCarga { get; set; } = string.Empty;
        public double Peso { get; set; }
        public string Destino { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }

        public int BuqueId { get; set; }
        public Buques? Buque { get; set; }

        public ICollection<Operaciones> Operaciones { get; set; } = new List<Operaciones>();
    }

}
