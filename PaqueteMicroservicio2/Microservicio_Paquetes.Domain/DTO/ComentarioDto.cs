using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.DTO
{
    public class ComentarioDto
    {
         public string fecha { get; set; }
         public string mensaje { get; set; }
         public int idDestino { get; set; }
         public int idPasajero { get; set; }
    }
}
