using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class PaqueteDestino
    {
        public int id { get; set; }
        public int idPaquete { get; set; }
        public Paquete Paquete { get; set; }
        public int idDestino { get; set; }
        public Destino Destino { get; set; }

    }
}
