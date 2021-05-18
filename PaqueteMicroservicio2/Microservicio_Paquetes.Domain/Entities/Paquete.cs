using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Paquete
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechasalida { get; set; }
        public string fechavuelta { get; set; }
        public int totalnoches { get; set; }
        public int precio { get; set; }
        public int descuento { get; set; }
        public int idPaqueteEstado { get; set; }
        public PaqueteEstado PaqueteEstado { get; set; }
        public int idEmpleado { get; set; }
        public ICollection<PaqueteViaje> PaqueteViajes { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<PaqueteHotel> PaqueteHoteles { get; set; }
        public ICollection<PaqueteDestino> PaqueteDestinos { get; set; }

    }
}
