using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.DTO
{
    public class HabitacionHotelDto
    {
        public int disponibles { get; set; }
        public int idTipoHabitacion { get; set; }
        public int idHotel { get; set; }
    }
}
