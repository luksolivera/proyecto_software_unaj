using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microservicio_Paquete.Domain.Queries;

namespace Microservicio_Paquete.AccessData.Queries
{
    public class GenericsRepositoryQueries : IRepositoryGenericQueries
    {
        private readonly TemplateDbContext _context;
        public GenericsRepositoryQueries(TemplateDbContext dbContext)
        {
            _context = dbContext;
        }

        public T FindBy<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> Traer<T>() where T : class
        {
            List<T> query = _context.Set<T>().ToList();
            return query;
        }
    }
}
