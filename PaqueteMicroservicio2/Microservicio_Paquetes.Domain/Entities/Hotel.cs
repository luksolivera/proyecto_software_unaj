using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Hotel
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string sucursal { get; set; }
        public int estrellas { get; set; }
        public bool bloqueado { get; set; }
        public int idDireccion { get; set; }
        public ICollection<DestinoHotel> DestinoHoteles { get; set; }
        public ICollection<HabitacionHotel> HabitacionHoteles { get; set; }
    }
}
