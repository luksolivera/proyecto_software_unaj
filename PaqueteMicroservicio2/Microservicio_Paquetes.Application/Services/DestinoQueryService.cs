using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoQueryService
    {
        IEnumerable<Destino> getDestinos();
        Destino getDestinoId(int id);
    }

    public class DestinoQueryService : IDestinoQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public DestinoQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<Destino> getDestinos()
        {
            return _repository.Traer<Destino>();
        }

        public Destino getDestinoId(int id)
        {
            return _repository.FindBy<Destino>(id);
        }
    }
}
