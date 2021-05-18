using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoHotelCommandService
    {
        DestinoHotel createDestinoHotel(DestinoHotel destinohotel);
        void deleteDestinoHotelId(int id);
    }

    public class DestinoHotelCommandService : IDestinoHotelCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public DestinoHotelCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public DestinoHotel createDestinoHotel(DestinoHotel destinohotel)
        {
            _repository.Add<DestinoHotel>(destinohotel);

            return destinohotel;
        }
        public void deleteDestinoHotelId(int id)
        {
            _repository.DeleteBy<DestinoHotel>(id);
        }
    }
}
