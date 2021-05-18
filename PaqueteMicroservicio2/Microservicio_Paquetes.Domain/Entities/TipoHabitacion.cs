using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class TipoHabitacion
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public int plazas { get; set; }
    }
}
