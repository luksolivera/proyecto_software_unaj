using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHabitacionHotelCommandService
    {
        HabitacionHotel createHabitacionHotel(HabitacionHotel habitacionhotel);
        void deleteHabitacionHotelId(int id);
    }

    public class HabitacionHotelCommandService : IHabitacionHotelCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public HabitacionHotelCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public HabitacionHotel createHabitacionHotel(HabitacionHotel habitacionhotel)
        {
            _repository.Add<HabitacionHotel>(habitacionhotel);

            return habitacionhotel;
        }
        public void deleteHabitacionHotelId(int id)
        {
            _repository.DeleteBy<HabitacionHotel>(id);
        }
    }
}
