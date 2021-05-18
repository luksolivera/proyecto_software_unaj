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
    public class HotelesController : ControllerBase
    {
        private readonly IHotelCommandService _commandservice;
        private readonly IHotelQueryService _queryservice;

        public HotelesController(IHotelCommandService commandservice, IHotelQueryService queryservice)
        {
            _commandservice = commandservice;
            _queryservice = queryservice;
        }



        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDto hotel)
        {
            Hotel nuevohotel = new Hotel();

            nuevohotel.marca = hotel.marca;
            nuevohotel.sucursal = hotel.sucursal;
            nuevohotel.estrellas = hotel.estrellas;
            nuevohotel.bloqueado = hotel.bloqueado;
            nuevohotel.idDireccion = hotel.idDireccion;

            _commandservice.createHotel(nuevohotel);

            return CreatedAtAction("PostHotel", new {id = nuevohotel.id, marca = nuevohotel.marca, sucursal = hotel.sucursal });
        }

        //[HttpGet]
        //public IEnumerable<Hotel> Get()
        //{
        //return _queryservice.getHoteles();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteles()
        {
            var listado = _queryservice.getHoteles();

            if (listado.Count() == 0)
                return NotFound();

            return listado.ToList();
        }

        //[HttpGet("{id}")]
        //public Hotel GetId(int id)
        //{
        //return _queryservice.getHotelId(id);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = _queryservice.getHotelId(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deleteHotelId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = _queryservice.getHotelId(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _commandservice.deleteHotelId(id);

            return hotel;
        }


    }
}
