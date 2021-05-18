using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoExcursionQueryService
    {
        IEnumerable<DestinoExcursion> getDestinoExcursiones();
        DestinoExcursion getDestinoExcursionId(int id);
    }

    public class DestinoExcursionQueryService : IDestinoExcursionQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public DestinoExcursionQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<DestinoExcursion> getDestinoExcursiones()
        {
            return _repository.Traer<DestinoExcursion>();
        }

        public DestinoExcursion getDestinoExcursionId(int id)
        {
            return _repository.FindBy<DestinoExcursion>(id);
        }
    }
}
