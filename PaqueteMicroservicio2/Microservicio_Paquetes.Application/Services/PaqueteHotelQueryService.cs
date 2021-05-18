using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteHotelQueryService
    {
        IEnumerable<PaqueteHotel> getPaqueteHoteles();
        PaqueteHotel getPaqueteHotelId(int id);
    }

    public class PaqueteHotelQueryService : IPaqueteHotelQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public PaqueteHotelQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<PaqueteHotel> getPaqueteHoteles()
        {
            return _repository.Traer<PaqueteHotel>();
        }

        public PaqueteHotel getPaqueteHotelId(int id)
        {
            return _repository.FindBy<PaqueteHotel>(id);
        }
    }
}
