using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHabitacionHotelQueryService
    {
        IEnumerable<HabitacionHotel> getHabitacionHoteles();
        HabitacionHotel getHabitacionHotelId(int id);
    }

    public class HabitacionHotelQueryService : IHabitacionHotelQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public HabitacionHotelQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<HabitacionHotel> getHabitacionHoteles()
        {
            return _repository.Traer<HabitacionHotel>();
        }

        public HabitacionHotel getHabitacionHotelId(int id)
        {
            return _repository.FindBy<HabitacionHotel>(id);
        }
    }
}
