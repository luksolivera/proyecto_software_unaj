using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IPaqueteDestinoCommandService
    {
        PaqueteDestino createPaqueteDestino(PaqueteDestino paquetedestino);
        void deletePaqueteDestinoId(int id);
    }

    public class PaqueteDestinoCommandService : IPaqueteDestinoCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public PaqueteDestinoCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public PaqueteDestino createPaqueteDestino(PaqueteDestino paquetedestino)
        {
            _repository.Add<PaqueteDestino>(paquetedestino);

            return paquetedestino;
        }
        public void deletePaqueteDestinoId(int id)
        {
            _repository.DeleteBy<PaqueteDestino>(id);
        }
    }
}
