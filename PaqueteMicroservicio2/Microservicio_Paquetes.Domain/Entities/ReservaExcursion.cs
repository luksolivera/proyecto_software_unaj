using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class ReservaExcursion
    {
        public int id { get; set; }
        public int idReserva { get; set; }
        public Reserva Reserva { get; set; }
        public int idExcursion { get; set; }
        public Excursion Excursion { get; set; }
    }
}
