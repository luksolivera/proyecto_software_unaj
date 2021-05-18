using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class PaqueteEstado
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public ICollection<Paquete> Paquetes { get; set; }
    }
}
