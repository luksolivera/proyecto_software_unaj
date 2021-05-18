using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class DestinoExcursion
    {
        public int id { get; set; }
        public int idDestino { get; set; }
        public Destino Destino { get; set; }
        public int idExcursion { get; set; }
        public Excursion Excursion { get; set; }
    }
}
