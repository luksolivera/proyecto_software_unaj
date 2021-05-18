using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class ReservaPasajero
    {
        public int id { get; set; }
        public int idReserva { get; set; }
        public Reserva Reserva { get; set; }
        public int idPasajero { get; set; }
        
    }
}
