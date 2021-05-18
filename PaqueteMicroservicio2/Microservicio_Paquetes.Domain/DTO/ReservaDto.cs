using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.DTO
{
    public class ReservaDto
    {
        public int id { get; set; }
        public int preciototal { get; set; }
        public int pasajeros { get; set; }
        public bool pagado { get; set; }
        public int idPasajero { get; set; }
        public int idFormaPago { get; set; }
        public int idPaquete { get; set; }
    }
}
