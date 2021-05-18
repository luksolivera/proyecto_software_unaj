using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Paquete.Domain.DTO
{
    public class ExcursionDto
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public bool bloqueada { get; set; }
        //public List<int> listadedestinos { get; set; }
    }
}
