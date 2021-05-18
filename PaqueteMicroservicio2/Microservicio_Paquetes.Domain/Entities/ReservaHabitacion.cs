using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class ReservaHabitacion
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public int idReserva { get; set; }
        public Reserva Reserva { get; set; }
        public int idHotel { get; set; }
        public Hotel Hotel { get; set; }
        public int idTipoHabitacion { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
