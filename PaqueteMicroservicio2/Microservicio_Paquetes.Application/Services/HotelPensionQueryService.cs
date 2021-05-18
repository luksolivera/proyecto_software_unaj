using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHotelPensionQueryService
    {
        IEnumerable<HotelPension> getHotelPensiones();
        HotelPension getHotelPensionId(int id);
    }

    public class HotelPensionQueryService : IHotelPensionQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public HotelPensionQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<HotelPension> getHotelPensiones()
        {
            return _repository.Traer<HotelPension>();
        }

        public HotelPension getHotelPensionId(int id)
        {
            return _repository.FindBy<HotelPension>(id);
        }
    }
}
