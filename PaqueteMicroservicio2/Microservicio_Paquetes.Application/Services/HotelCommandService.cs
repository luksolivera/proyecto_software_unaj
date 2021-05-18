using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHotelCommandService
    {
        Hotel createHotel(Hotel hotel);
        void deleteHotelId(int id);
    }

    public class HotelCommandService: IHotelCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public HotelCommandService (IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public Hotel createHotel(Hotel hotel)
        {
            _repository.Add<Hotel>(hotel);

            return hotel;
        }
        public void deleteHotelId(int id)
        {
            _repository.DeleteBy<Hotel>(id);
        }
    }
}
