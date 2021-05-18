using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microservicio_Paquete.Domain.Entities;

namespace Microservicio_Paquete.AccessData
{
    public class TemplateDbContext: DbContext 
    {

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {

        }
        public DbSet<Paquete> Paquetes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=mspaquetes;Trusted_Connection=True;");
        }

    }
}
