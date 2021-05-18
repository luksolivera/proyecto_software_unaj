using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class DestinoHotel
    {
        public int id { get; set; }
        public int idDestino { get; set; }
        public int idHotel { get; set; }
    }
}
