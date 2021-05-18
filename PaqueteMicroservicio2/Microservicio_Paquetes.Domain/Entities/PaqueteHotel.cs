using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class PaqueteHotel
    {
        public int id { get; set; }
        public int noches { get; set; }
        public int idPaquete { get; set; }
        public Paquete Paquete { get; set; }
        public int idHotel { get; set; }
        public Hotel Hotel { get; set; }
        public int idHotelPension { get; set; }
        public HotelPension HotelPension { get; set; }

    }
}
