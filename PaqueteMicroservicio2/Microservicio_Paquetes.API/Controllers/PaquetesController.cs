using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.Commands;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Application.Services;

namespace Microservicio_Paquete.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteCommandService _commandservice;
        private readonly IPaqueteQueryService _queryservice;
        private readonly IDestinoQueryService _queryserviceDestino;
        private readonly IHotelQueryService _queryserviceHotel;
        private readonly IPaqueteHotelCommandService _commandservicePaqueteHotel;
        private readonly IPaqueteDestinoCommandService _commandservicePaqueteDestino;
        private readonly IPaqueteEstadoQueryService _queryserviceEstadoPaquete;
        private readonly IHotelPensionQueryService _queryserviceHotelPension;

        public PaquetesController(IPaqueteCommandService commandservice, IPaqueteQueryService queryservice,
            IDestinoQueryService queryserviceDestino, IHotelQueryService queryserviceHotel,
            IPaqueteHotelCommandService commandservicePaqueteHotel, IPaqueteDestinoCommandService commandservicePaqueteDestino,
            IPaqueteEstadoQueryService queryserviceEstadoPaquete, IHotelPensionQueryService queryserviceHotelPension)
        {
            _commandservice = commandservice;
            _queryservice = queryservice;
            _queryserviceDestino = queryserviceDestino;
            _queryserviceHotel = queryserviceHotel;
            _commandservicePaqueteHotel = commandservicePaqueteHotel;
            _commandservicePaqueteDestino = commandservicePaqueteDestino;
            _queryserviceEstadoPaquete = queryserviceEstadoPaquete;
            _queryserviceHotelPension = queryserviceHotelPension;

        }



        //[HttpPost]
        //blic Paquete Post(PaqueteDto paquete)
        //{
        //return _commandservice.createPaquete(paquete);

        //}

        [HttpPost]
        public async Task<ActionResult<Excursion>> PostPaquete(PaqueteDto paquete)
        {
            Paquete paquetenuevo = new Paquete();

            ////Chequear si todos los destinos sumistrados existen

            //foreach (List<int> x in paquete.listadestinoshotelesnoches)
            //{
            //    var destino = _queryserviceDestino.getDestinoId(x[0]);
            //    if (destino == null)
            //    {
            //        return BadRequest();
            //    }
            //}

            ////Chequear si todos los hoteles sumistrados existen

            //foreach (List<int> x in paquete.listadestinoshotelesnoches)
            //{
            //    var hotel = _queryserviceHotel.getHotelId(x[1]);
            //    if (hotel == null)
            //    {
            //        return BadRequest();
            //    }
            //}

            ////Chequear si todos los tipos de pensiones sumistradas existen

            //foreach (List<int> x in paquete.listadestinoshotelesnoches)
            //{
            //    var hotelpension = _queryserviceHotelPension.getHotelPensionId(x[3]);
            //    if (hotelpension == null)
            //    {
            //        return BadRequest();
            //    }
            //}

            ////Chequear si el estado de paquete es valido

            //var estadopaquete = _queryserviceEstadoPaquete.getPaqueteEstadoId(paquete.idPaqueteEstado);

            //if (estadopaquete == null)
            //{
            //    return BadRequest();
            //}

            // Si todos existen, agregar todas las instancias de PaqueteDestino

            //foreach (List<int> x in paquete.listadestinoshotelesnoches)
            //{
            //    PaqueteDestino paquetedestino = new PaqueteDestino();
            //    paquetedestino.idDestino = x[0];
            //    paquetedestino.idPaquete = paquetenuevo.id;
            //    _commandservicePaqueteDestino.createPaqueteDestino(paquetedestino);
            //}

            //// Agregar todas las instancias de PaqueteHotel

            //int totalnochescontador = 0;

            //foreach (List<int> x in paquete.listadestinoshotelesnoches)
            //{
            //    PaqueteHotel paquetehotel = new PaqueteHotel();
            //    paquetehotel.idHotel = x[1];
            //    paquetehotel.idPaquete = paquetenuevo.id;
            //    paquetehotel.noches = x[2];
            //    paquetehotel.idHotelPension = x[3];
            //    totalnochescontador = totalnochescontador + x[2];
            //    _commandservicePaqueteHotel.createPaqueteHotel(paquetehotel);
            //}

            // Crear el paquete

            paquetenuevo.nombre = paquete.nombre;
            paquetenuevo.descripcion = paquete.descripcion;
            paquetenuevo.fechasalida = paquete.fechasalida;
            paquetenuevo.fechavuelta = paquete.fechavuelta;
            paquetenuevo.idPaqueteEstado = paquete.idPaqueteEstado;
            paquetenuevo.totalnoches = 0;
            paquetenuevo.precio = paquete.precio;
            paquetenuevo.descuento = paquete.descuento;

            // Finalmente agregar el paquete

            _commandservice.createPaquete(paquetenuevo);

            return CreatedAtAction("PostPaquete", new { id = paquetenuevo.id, nombre=paquete.nombre, descripcion = paquete.descripcion });



            //_commandservice.createDestino(destino);

            //return CreatedAtAction("Get", new { descripcion = destino.descripcion });
        }

        //[HttpGet]
        //public IEnumerable<Paquete> Get()
        //{
        //return _queryservice.getPaquetes();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetes()
        {
            var listado = _queryservice.getPaquetes();

            if (listado.Count() == 0)
                return NotFound();

            return listado.ToList();
        }

        //[HttpGet("{id}")]
        //public Paquete GetId(int id)
        //{
        //return _queryservice.getPaqueteId(id);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Paquete>> GetPaquete(int id)
        {
            var paquete = _queryservice.getPaqueteId(id);

            if (paquete == null)
            {
                return NotFound();
            }

            return paquete;
        }

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deletePaqueteId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Paquete>> DeletePaquete(int id)
        {
            var paquete = _queryservice.getPaqueteId(id);
            if (paquete == null)
            {
                return NotFound();
            }

            _commandservice.deletePaqueteId(id);

            return paquete;
        }


    }
}
