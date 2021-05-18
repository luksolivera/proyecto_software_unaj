using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHotelQueryService
    {
        IEnumerable<Hotel> getHoteles();
        Hotel getHotelId(int id);
    }

    public class HotelQueryService : IHotelQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public HotelQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<Hotel> getHoteles()
        {
            return _repository.Traer<Hotel>();
        }

        public Hotel getHotelId(int id)
        {
            return _repository.FindBy<Hotel>(id);
        }
    }
}
