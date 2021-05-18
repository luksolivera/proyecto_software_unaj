using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.DTO
{
    public class HotelDto
    {
        public string marca { get; set; }
        public string sucursal { get; set; }
        public int estrellas { get; set; }
        public bool bloqueado { get; set; }
        public int idDireccion { get; set; }
    }
}
