using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Reserva
    {
        public int id { get; set; }
        public int preciototal { get; set; }
        public int pasajeros { get; set; }
        public bool pagado { get; set; }
        public int idPasajero { get; set; }
        public int idFormaPago { get; set; }
        public FormaPago FormaPago { get; set; }
        public int idPaquete { get; set; }
        public ICollection<ReservaExcursion> ReservaExcursiones { get; set; }
        public ICollection<ReservaHabitacion> ReservaHabitaciones { get; set; }

    }
}
