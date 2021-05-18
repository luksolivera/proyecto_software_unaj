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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioCommandService _commandservice;
        private readonly IComentarioQueryService _queryservice;

        public ComentarioController(IComentarioCommandService commandservice, IComentarioQueryService queryservice)
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
       public async Task<ActionResult<Comentario>> PostComentario(ComentarioDto comentario)
       {
            Comentario nuevoComentario = new Comentario();

            nuevoComentario.fecha = comentario.fecha;
            nuevoComentario.mensaje = comentario.mensaje;
            nuevoComentario.idDestino = comentario.idDestino;
            nuevoComentario.idPasajero = comentario.idPasajero;

            _commandservice.createComentario(nuevoComentario);

            return CreatedAtAction("PostComentario", new { id = nuevoComentario.id, mensaje = nuevoComentario.mensaje,
                iddestino = nuevoComentario.idDestino, idpasajero = nuevoComentario.idPasajero });
       }

        //[HttpGet]
        //public IEnumerable<Destino> Get()
        //{
        //return _queryservice.getDestinos();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestino()
        {
            var listado = _queryservice.getComentarios();

            if (listado.Count() == 0)
                return NotFound();

            return Ok(listado);
        }

        //[HttpGet("{id}")]
        //public Destino GetId(int id)
        //{
        //return _queryservice.getDestinoId(id);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetComentario(int id)
        {
            var comentario = _queryservice.getComentarioId(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deleteDestinoId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> DeleteComentario(int id)
        {
            var comentario = _queryservice.getComentarioId(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _commandservice.deleteComentarioId(id);

            return comentario;
        }


    }
}
