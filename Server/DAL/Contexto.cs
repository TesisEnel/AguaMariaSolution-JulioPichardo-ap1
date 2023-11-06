using Microsoft.EntityFrameworkCore;
using AguaMariaSolution.Shared.Models;

namespace AguaMariaSolution.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<ControlCalidadProductoTerminado> ControlCalidadProductoTerminado { get; set; }
        public DbSet<ProductoTerminadosDetalle> ProductoTerminadosDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parametros>().HasData(new List<Parametros>()
        {
            new Parametros(){ParametroId=1, Descripción="Cloruro", Mínimo = 0, Máximo = 1,},
            
        });
        }
    }
}

