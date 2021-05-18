using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microservicio_Paquete.Domain.Commands;

namespace Microservicio_Paquete.AccessData.Commands
{
    public class GenericsRepositoryCommands : IRepositoryGenericCommands
    {
        private readonly TemplateDbContext _context;
        public GenericsRepositoryCommands(TemplateDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteBy<T>(int id) where T : class
        {
            T entity = FindBy<T>(id);
            Delete<T>(entity);
        }

        private T FindBy<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Agregado por Emil
        public void UpdateBy<T>(int id) where T : class
        {
            T entity = FindBy<T>(id);
            Update<T>(entity);
        }
    }
}
