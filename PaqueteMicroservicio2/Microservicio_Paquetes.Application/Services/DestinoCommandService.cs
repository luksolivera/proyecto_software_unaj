using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IDestinoCommandService
    {
        Destino createDestino(Destino destino);
        void deleteDestinoId(int id);
    }

    public class DestinoCommandService : IDestinoCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public DestinoCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public Destino createDestino(Destino destino)
        {
            _repository.Add<Destino>(destino);

            return destino;
        }
        public void deleteDestinoId(int id)
        {
            _repository.DeleteBy<Destino>(id);
        }
    }
}
