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
    public class ExcursionController : ControllerBase
    {
        private readonly IExcursionCommandService _commandservice;
        private readonly IExcursionQueryService _queryservice;
        private readonly IDestinoQueryService _queryserviceDestino;
        private readonly IDestinoExcursionCommandService _commandserviceDestinoExcursion;

        public ExcursionController(IExcursionCommandService commandservice, IExcursionQueryService queryservice, IDestinoQueryService queryserviceDestino, IDestinoExcursionCommandService commandserviceDestinoExcursion)
        {
            _commandservice = commandservice;
            _queryservice = queryservice;
            _queryserviceDestino = queryserviceDestino;
            _commandserviceDestinoExcursion = commandserviceDestinoExcursion;
        }



        //[HttpPost]
        //public Destino Post(DestinoDto destino)
        //{
        //return _commandservice.createDestino(destino);

        //}

        [HttpPost]
        public async Task<ActionResult<Excursion>> PostExcursion(ExcursionDto excursion)
        {
            Excursion excursionnueva = new Excursion();

            // Chequear si todos los destinos sumistrados existen

            //foreach(int x in excursion.listadedestinos)
            //{
            //    var destino = _queryserviceDestino.getDestinoId(x);
            //    if (destino == null)
            //    {
            //        return BadRequest();
            //    }
            //}

            //// Si todos existen, agregar todas las instancias de DestinoExcursion

            //foreach (int x in excursion.listadedestinos)
            //{
            //    DestinoExcursion destinoexcursion = new DestinoExcursion();
            //    destinoexcursion.idDestino = x;
            //    destinoexcursion.idExcursion = excursionnueva.id;
            //    _commandserviceDestinoExcursion.createDestinoExcursion(destinoexcursion);
            //}

            // Crear la excursion

            excursionnueva.descripcion = excursion.descripcion;
            excursionnueva.titulo = excursion.titulo;
            excursionnueva.bloqueada = excursion.bloqueada;
            excursionnueva.precio = excursion.precio;

            // Finalmente agregar la excursion

            _commandservice.createExcursion(excursionnueva);

            return CreatedAtAction("PostExcursion", new { id = excursionnueva.id, titulo = excursion.titulo});



            //_commandservice.createDestino(destino);

            //return CreatedAtAction("Get", new { descripcion = destino.descripcion });
        }

        //[HttpGet]
        //public IEnumerable<Excursion> Get()
        //{
        //return _queryservice.getExcursiones();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Excursion>> GetExcursion(int id)
        {
            var excursion = _queryservice.getExcursionId(id);

            if (excursion == null)
            {
                return NotFound();
            }

            return excursion;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excursion>>> GetExcursion()
        {
            var listado = _queryservice.getExcursiones();

            if (listado.Count() == 0)
                return NotFound();

            return listado.ToList();
        }

        //[HttpGet("{id}")]
        //public Excursion GetId(int id)
        //{
        //return _queryservice.getExcursionId(id);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deleteExcursionId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Excursion>> DeleteExcursion(int id)
        {
            var excursion = _queryservice.getExcursionId(id);
            if (excursion == null)
            {
                return NotFound();
            }

            _commandservice.deleteExcursionId(id);

            return excursion;
        }


    }
}
