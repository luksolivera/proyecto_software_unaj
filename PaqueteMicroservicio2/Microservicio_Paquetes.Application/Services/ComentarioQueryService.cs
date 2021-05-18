using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface IComentarioQueryService
    {
        IEnumerable<Comentario> getComentarios();
        Comentario getComentarioId(int id);
    }

    public class ComentarioQueryService : IComentarioQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public ComentarioQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<Comentario> getComentarios()
        {
            return _repository.Traer<Comentario>();
        }

        public Comentario getComentarioId(int id)
        {
            return _repository.FindBy<Comentario>(id);
        }
    }
}
