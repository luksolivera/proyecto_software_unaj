using System;
using System.Collections.Generic;
using System.Text;


namespace Microservicio_Paquete.Domain.DTO
{
    public class PaqueteDto
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechasalida { get; set; }
        public string fechavuelta { get; set; }
        //public int totalnoches { get; set; }
        //no se necesita, se calcular automaticamente
        public int precio { get; set; }
        public int descuento { get; set; }
        public int idPaqueteEstado { get; set; }

        //Lista de listas con 4 elementos: (destino, hotel, cantidad de noches, tipodepension)
        //public List<List<int>> listadestinoshotelesnoches { get; set; }
    }
}
