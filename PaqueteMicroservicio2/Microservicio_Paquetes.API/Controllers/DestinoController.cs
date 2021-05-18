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
    public class DestinoController : ControllerBase
    {
        private readonly IDestinoCommandService _commandservice;
        private readonly IDestinoQueryService _queryservice;

        public DestinoController(IDestinoCommandService commandservice, IDestinoQueryService queryservice)
        {
            _commandservice = commandservice;
            _queryservice = queryservice;
        }



        //[HttpPost]
        //public Destino Post(DestinoDto destino)
        //{
            //Destino nuevodestino = new Destino();

            //nuevodestino.lugar = destino.lugar;
            //nuevodestino.descripcion = destino.descripcion;
            //nuevodestino.atractivo = destino.atractivo;
            //nuevodestino.historia = destino.historia;

            //return _commandservice.createDestino(nuevodestino);

        //}

       [HttpPost]
       public async Task<ActionResult<Destino>> PostDestino(DestinoDto destino)
       {
            Destino nuevodestino = new Destino();

            nuevodestino.lugar = destino.lugar;
            nuevodestino.descripcion = destino.descripcion;
            nuevodestino.atractivo = destino.atractivo;
            nuevodestino.historia = destino.historia;

            _commandservice.createDestino(nuevodestino);

            return CreatedAtAction("PostDestino", new { id = nuevodestino.id, lugar = destino.lugar, descripcion = destino.descripcion });
       }

        //[HttpGet]
        //public IEnumerable<Destino> Get()
        //{
        //return _queryservice.getDestinos();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestino()
        {
            var listado = _queryservice.getDestinos();

            if (listado.Count() == 0)
                return NotFound();

            return listado.ToList();
        }

        //[HttpGet("{id}")]
        //public Destino GetId(int id)
        //{
        //return _queryservice.getDestinoId(id);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetDestino(int id)
        {
            var destino = _queryservice.getDestinoId(id);

            if (destino == null)
            {
                return NotFound();
            }

            return destino;
        }

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deleteDestinoId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Destino>> DeleteDestino(int id)
        {
            var destino = _queryservice.getDestinoId(id);
            if (destino == null)
            {
                return NotFound();
            }

            _commandservice.deleteDestinoId(id);

            return destino;
        }


    }
}
