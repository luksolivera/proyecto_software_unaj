using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.Application.Services
{
    public interface ITipoHabitacionQueryService
    {
        IEnumerable<TipoHabitacion> getTipoHabitaciones();
        TipoHabitacion getTipoHabitacionId(int id);
    }

    public class TipoHabitacionQueryService : ITipoHabitacionQueryService
    {
        private readonly IRepositoryGenericQueries _repository;

        public TipoHabitacionQueryService(IRepositoryGenericQueries repository)
        {
            _repository = repository;
        }

        public IEnumerable<TipoHabitacion> getTipoHabitaciones()
        {
            return _repository.Traer<TipoHabitacion>();
        }

        public TipoHabitacion getTipoHabitacionId(int id)
        {
            return _repository.FindBy<TipoHabitacion>(id);
        }
    }
}
