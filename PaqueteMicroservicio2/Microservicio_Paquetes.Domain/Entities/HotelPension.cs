using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class HotelPension
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public ICollection<PaqueteHotel> PaqueteHoteles { get; set; }
    }
}
