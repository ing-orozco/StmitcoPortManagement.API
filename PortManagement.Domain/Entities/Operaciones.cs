using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManagement.Domain.Entities
{
    public class Operaciones
    {
        public int Id { get; set; }
        public int BuqueId { get; set; }
        public Buques? Buque { get; set; }

        public int CargaId { get; set; }
        public Cargas? Carga { get; set; }

        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }

        public string TipoOperacion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = string.Empty;
    }

}
