using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteCommandService
    {
        Paquete createPaquete(Paquete paquete);
        void deletePaqueteId(int id);
    }

    public class PaqueteCommandService: IPaqueteCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public PaqueteCommandService (IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public Paquete createPaquete(Paquete paquete)
        {
            _repository.Add<Paquete>(paquete);

            return paquete;
        }
        public void deletePaqueteId(int id)
        {
            _repository.DeleteBy<Paquete>(id);
        }
    }
}
