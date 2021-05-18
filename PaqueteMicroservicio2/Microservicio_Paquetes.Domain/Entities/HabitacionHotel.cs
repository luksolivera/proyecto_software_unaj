using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class HabitacionHotel
    {
        public int id { get; set; }
        public int idTipoHabitacion { get; set; }
        public int disponibles { get; set; }
        public int idHotel { get; set; }
    }
}
