using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IComentarioCommandService
    {
        Comentario createComentario(Comentario comentario);
        void deleteComentarioId(int id);
    }

    public class ComentarioCommandService : IComentarioCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public ComentarioCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public Comentario createComentario(Comentario comentario)
        {
            _repository.Add<Comentario>(comentario);

            return comentario;
        }
        public void deleteComentarioId(int id)
        {
            _repository.DeleteBy<Comentario>(id);
        }
    }
}
