using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoExcursionCommandService
    {
        DestinoExcursion createDestinoExcursion(DestinoExcursion destinoexcursion);
        void deleteDestinoExcursionId(int id);
    }

    public class DestinoExcursionCommandService : IDestinoExcursionCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public DestinoExcursionCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public DestinoExcursion createDestinoExcursion(DestinoExcursion destinoexcursion)
        {
            var entity = new DestinoExcursion()
            {
                idExcursion = destinoexcursion.idExcursion,
                idDestino = destinoexcursion.idDestino
            };


            _repository.Add<DestinoExcursion>(entity);

            return entity;
        }
        public void deleteDestinoExcursionId(int id)
        {
            _repository.DeleteBy<DestinoExcursion>(id);
        }
    }
}
