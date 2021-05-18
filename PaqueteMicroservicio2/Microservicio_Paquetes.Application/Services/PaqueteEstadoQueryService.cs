using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteEstadoQueryService
    {
        IEnumerable<PaqueteEstado> getPaqueteEstados();
        PaqueteEstado getPaqueteEstadoId(int id);
    }

    public class PaqueteEstadoQueryService : IPaqueteEstadoQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public PaqueteEstadoQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<PaqueteEstado> getPaqueteEstados()
        {
            return _repository.Traer<PaqueteEstado>();
        }

        public PaqueteEstado getPaqueteEstadoId(int id)
        {
            return _repository.FindBy<PaqueteEstado>(id);
        }
    }
}
