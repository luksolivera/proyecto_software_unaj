using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteEstadoCommandService
    {
        PaqueteEstado createPaqueteEstado(PaqueteEstado paqueteestado);
        void deletePaqueteEstadoId(int id);
    }

    public class PaqueteEstadoCommandService : IPaqueteEstadoCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public PaqueteEstadoCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public PaqueteEstado createPaqueteEstado(PaqueteEstado paqueteestado)
        {
            _repository.Add<PaqueteEstado>(paqueteestado);

            return paqueteestado;
        }
        public void deletePaqueteEstadoId(int id)
        {
            _repository.DeleteBy<PaqueteEstado>(id);
        }
    }
}
