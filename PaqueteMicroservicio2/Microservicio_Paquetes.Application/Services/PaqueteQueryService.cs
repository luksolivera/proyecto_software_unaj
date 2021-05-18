using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteQueryService
    {
        IEnumerable<Paquete> getPaquetes();
        Paquete getPaqueteId(int id);
    }

    public class PaqueteQueryService: IPaqueteQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public PaqueteQueryService (IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<Paquete> getPaquetes()
        {
            return _repository.Traer<Paquete>();
        }

        public Paquete getPaqueteId(int id)
        {
            return _repository.FindBy<Paquete>(id);
        }
    }
}
