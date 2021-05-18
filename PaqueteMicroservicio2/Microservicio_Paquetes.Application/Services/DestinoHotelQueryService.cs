using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoHotelQueryService
    {
        IEnumerable<DestinoHotel> getDestinoHoteles();
        DestinoHotel getDestinoHotelesId(int id);
    }

    public class DestinoHotelQueryService : IDestinoHotelQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public DestinoHotelQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<DestinoHotel> getDestinoHoteles()
        {
            return _repository.Traer<DestinoHotel>();
        }

        public DestinoHotel getDestinoHotelesId(int id)
        {
            return _repository.FindBy<DestinoHotel>(id);
        }
    }
}
