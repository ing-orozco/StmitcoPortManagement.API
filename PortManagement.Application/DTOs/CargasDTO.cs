using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManagement.Application.DTOs
{
    public class CargaDto
    {
        public int Id { get; set; }
        public string TipoCarga { get; set; }
        public int Peso { get; set; }
        public string Destino { get; set; }
        public BuqueDTO Buque { get; set; }
    }
}
