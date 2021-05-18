using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Excursion
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public bool bloqueada { get; set; }
        public ICollection<DestinoExcursion> DestinoExcursiones { get; set; }
        public ICollection<ReservaExcursion> ReservaExcursiones { get; set; }

    }
}
