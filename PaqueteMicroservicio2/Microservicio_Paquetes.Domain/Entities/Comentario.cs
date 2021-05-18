using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Comentario
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string mensaje { get; set; }
        public int idDestino { get; set; }
        public Destino Destino { get; set; }
        public int idPasajero { get; set; }
    }
}
