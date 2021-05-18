using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteDestinoQueryService
    {
        IEnumerable<PaqueteDestino> getPaqueteDestinos();
        PaqueteDestino getPaqueteDestinoId(int id);
    }

    public class PaqueteDestinoQueryService : IPaqueteDestinoQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public PaqueteDestinoQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<PaqueteDestino> getPaqueteDestinos()
        {
            return _repository.Traer<PaqueteDestino>();
        }

        public PaqueteDestino getPaqueteDestinoId(int id)
        {
            return _repository.FindBy<PaqueteDestino>(id);
        }
    }
}
