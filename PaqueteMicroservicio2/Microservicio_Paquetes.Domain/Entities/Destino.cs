using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.Entities
{
    public class Destino
    {
        public int id { get; set; }
        public string lugar { get; set; }
        public string descripcion { get; set; }
        public string atractivo { get; set; }
        public string historia { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<PaqueteDestino> PaqueteDestinos { get; set; }
        public ICollection<DestinoExcursion> DestinoExcursiones { get; set; }
        public ICollection<DestinoHotel> DestinoHoteles { get; set; }
    }
}
