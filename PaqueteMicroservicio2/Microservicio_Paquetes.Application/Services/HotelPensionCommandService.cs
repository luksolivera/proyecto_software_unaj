using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquete.Domain.Entities;
using Microservicio_Paquete.Domain.DTO;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.Application.Services
{
    public interface IHotelPensionCommandService
    {
        HotelPension createHotelPension(HotelPension hotelpension);
        void deleteHotelPensionId(int id);
    }

    public class HotelPensionCommandService : IHotelPensionCommandService
    {
        private readonly IRepositoryGenericCommands _repository;

        public HotelPensionCommandService(IRepositoryGenericCommands repository)
        {
            _repository = repository;
        }

        public HotelPension createHotelPension(HotelPension hotelpension)
        {
            _repository.Add<HotelPension>(hotelpension);

            return hotelpension;
        }
        public void deleteHotelPensionId(int id)
        {
            _repository.DeleteBy<HotelPension>(id);
        }
    }
}
