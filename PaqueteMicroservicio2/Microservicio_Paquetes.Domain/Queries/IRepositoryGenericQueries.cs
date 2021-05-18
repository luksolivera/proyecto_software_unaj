using System;
using System.Collections.Generic;
using System.Text;


namespace Microservicio_Paquete.Domain.Queries
{
    public interface IRepositoryGenericQueries
    {
        List<T> Traer<T>() where T : class;
        T FindBy<T>(int id) where T : class;        
    }
}
