using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteHotelCommandService
    {
        PaqueteHotel createPaqueteHotel(PaqueteHotel paquetehotel);
        void deletePaqueteHotelId(int id);
    }

    public class PaqueteHotelCommandService : IPaqueteHotelCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public PaqueteHotelCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public PaqueteHotel createPaqueteHotel(PaqueteHotel paquetehotel)
        {
            _repository.Add<PaqueteHotel>(paquetehotel);

            return paquetehotel;
        }
        public void deletePaqueteHotelId(int id)
        {
            _repository.DeleteBy<PaqueteHotel>(id);
        }
    }
}
