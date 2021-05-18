using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface ITipoHabitacionCommandService
    {
        TipoHabitacion createTipoHabitacion(TipoHabitacion tipohabitacion);
        void deleteTipoHabitacionId(int id);
    }

    public class TipoHabitacionCommandService : ITipoHabitacionCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public TipoHabitacionCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public TipoHabitacion createTipoHabitacion(TipoHabitacion tipohabitacion)
        {
            _repository.Add<TipoHabitacion>(tipohabitacion);

            return tipohabitacion;
        }
        public void deleteTipoHabitacionId(int id)
        {
            _repository.DeleteBy<TipoHabitacion>(id);
        }
    }
}
