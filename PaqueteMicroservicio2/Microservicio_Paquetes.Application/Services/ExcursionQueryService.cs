using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IExcursionQueryService
    {
        IEnumerable<Excursion> getExcursiones();
        Excursion getExcursionId(int id);
    }

    public class ExcursionQueryService : IExcursionQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public ExcursionQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<Excursion> getExcursiones()
        {
            return _repository.Traer<Excursion>();
        }

        public Excursion getExcursionId(int id)
        {
            return _repository.FindBy<Excursion>(id);
        }
    }
}
