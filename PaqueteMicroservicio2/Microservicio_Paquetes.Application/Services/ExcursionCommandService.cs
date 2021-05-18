using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IExcursionCommandService
    {
        Excursion createExcursion(Excursion excursion);
        void deleteExcursionId(int id);
    }

    public class ExcursionCommandService : IExcursionCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public ExcursionCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public Excursion createExcursion(Excursion excursion)
        {
            _repository.Add<Excursion>(excursion);

            return excursion;
        }
        public void deleteExcursionId(int id)
        {
            _repository.DeleteBy<Excursion>(id);
        }
    }
}
