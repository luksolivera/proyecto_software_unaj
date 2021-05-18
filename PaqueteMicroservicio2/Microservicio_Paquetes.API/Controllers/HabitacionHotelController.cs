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
    public class HabitacionHotelController : ControllerBase
    {
        private readonly IHabitacionHotelCommandService _commandservice;
        private readonly IHabitacionHotelQueryService _queryservice;
        private readonly IHotelQueryService _queryserviceHotel;
        private readonly ITipoHabitacionQueryService _queryserviceTipoHabitacion;

        public HabitacionHotelController(IHabitacionHotelCommandService commandservice, IHabitacionHotelQueryService queryservice, IHotelQueryService queryserviceHotel, ITipoHabitacionQueryService queryserviceTipoHabitacion)
        {
            _commandservice = commandservice;
            _queryservice = queryservice;
            _queryserviceHotel = queryserviceHotel;
            _queryserviceTipoHabitacion = queryserviceTipoHabitacion;
        }



        //[HttpPost]
        //public HabitacionHotel Post(HabitacionHotelDto habitacionhotel)
        //{

           // return _commandservice.createHabitacionHotel(habitacionhotel);

        //}

        [HttpPost]
        public async Task<ActionResult<HabitacionHotel>> PostHabitacionHotel(HabitacionHotelDto habitacionhotel)
        {
            HabitacionHotel nuevahabitacionhotel = new HabitacionHotel();

            var hotel = _queryserviceHotel.getHotelId(habitacionhotel.idHotel);
            {
                if (hotel == null)
                {
                    return BadRequest();
                }
            }

            //var tipohabitacion = _queryserviceTipoHabitacion.getTipoHabitacionId(habitacionhotel.idTipoHabitacion);
            //{
                //if (tipohabitacion == null)
                //{
                    //return BadRequest();
                //}
            //}

            nuevahabitacionhotel.idHotel = habitacionhotel.idHotel;
            nuevahabitacionhotel.idTipoHabitacion = habitacionhotel.idTipoHabitacion;
            nuevahabitacionhotel.disponibles = habitacionhotel.disponibles;

            _commandservice.createHabitacionHotel(nuevahabitacionhotel);

            return CreatedAtAction("PostHabitacionHotel", habitacionhotel);


            //_context.Mercaderia.Add(mercaderia);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMercaderia", new { id = mercaderia.MercaderiaId }, mercaderia);
        }

        //[HttpGet]
        //public IEnumerable<HabitacionHotel> Get()
        //{
        //return _queryservice.getHabitacionHoteles();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitacionHotel>>> GetHabitacionHoteles()
        {
            var listado = _queryservice.getHabitacionHoteles();

            if (listado.Count() == 0)
                return NotFound();

            return listado.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HabitacionHotel>> GetHabitacionHotel(int id)
        {
            var habitacionhotel = _queryservice.getHabitacionHotelId(id);

            if (habitacionhotel == null)
            {
                return NotFound();
            }

            return habitacionhotel;
        }

        //[HttpGet("{id}")]
        //public HabitacionHotel GetId(int id)
        //{
            //return _queryservice.getHabitacionHotelId(id);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteId(int id)
        //{
        //_commandservice.deleteHabitacionHotelId(id);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<HabitacionHotel>> DeleteHabitacionHotel(int id)
        {
            var habitacionhotel = _queryservice.getHabitacionHotelId(id);
            if (habitacionhotel == null)
            {
                return NotFound();
            }

            _commandservice.deleteHabitacionHotelId(id);

            return habitacionhotel;
        }


    }
}
