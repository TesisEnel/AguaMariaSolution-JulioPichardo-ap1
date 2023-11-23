using AguaMariaSolution.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AguaMariaSolution.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<RecordLavadoraBotellones> RecordLavadoraBotellones { get; set; }
        public DbSet<ControlCalidadProductoTerminado> ControlCalidadProductoTerminado { get; set; }
        public DbSet<ProductoTerminadosDetalle> ProductoTerminadosDetalle { get; set; }
        public DbSet<ControlCalidadAgua> ControlCalidadAgua { get; set; }
        public DbSet<ControlCalidadAguaDetalle> ControlCalidadAguaDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parametros>().HasData(new List<Parametros>()
            {
                //ControlCalidadProductoTerminado
            new Parametros() {ParametroId = 1, Descripción = "Cloruro", Mínimo = 0, Máximo = 250},
            new Parametros() {ParametroId = 2, Descripción = "Cloro Residual", Mínimo = 0, Máximo = 0},
            new Parametros() {ParametroId = 3, Descripción = "STD", Mínimo = 0, Máximo = 500},
            new Parametros() {ParametroId = 4, Descripción = "Conductancia", Mínimo = 0, Máximo = 700},
            new Parametros() {ParametroId = 5, Descripción = "Dureza", Mínimo = 0, Máximo = 500},
            new Parametros() {ParametroId = 6, Descripción = "PH", Mínimo = 6.5f, Máximo = 8.5f},
            new Parametros() {ParametroId = 7, Descripción = "Sulfato", Mínimo = 0, Máximo = 250},
            new Parametros() {ParametroId = 8, Descripción = "Nitrato", Mínimo = 0, Máximo = 10},
            new Parametros() {ParametroId = 9, Descripción = "Hierro", Mínimo = 0, Máximo = 0.3f},
            new Parametros() {ParametroId = 10, Descripción = "Color", Mínimo = 0, Máximo = 5},
            new Parametros() {ParametroId = 11, Descripción = "Turbidez", Mínimo = 0, Máximo = 0.5f},
            new Parametros() {ParametroId = 12, Descripción = "Sabor", Mínimo = 1, Máximo = 1},
            new Parametros() {ParametroId = 13, Descripción = "Ozono", Mínimo = 0.05f, Máximo = 0.1f},
            new Parametros() {ParametroId = 14, Descripción = "Lamp UV", Mínimo = 1, Máximo = 1},

                //Entidades de Cisternar e INAPA - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 20, Descripción = "Cloro Residual", Mínimo = 1, Máximo = 1.5f},
            new Parametros() {ParametroId = 21, Descripción = "Dureza", Mínimo = 68.4f, Máximo = 500},
            new Parametros() {ParametroId = 22, Descripción = "STD", Mínimo = 70, Máximo = 1000},
            new Parametros() {ParametroId = 23, Descripción = "Color", Mínimo = 5, Máximo = 15},
            new Parametros() {ParametroId = 24, Descripción = "Turbidez", Mínimo = 10, Máximo = 25},
            new Parametros() {ParametroId = 25, Descripción = "Sulfato", Mínimo = 250, Máximo = 400},
            new Parametros() {ParametroId = 26, Descripción = "Nitrato", Mínimo = 10, Máximo = 50},
            new Parametros() {ParametroId = 27, Descripción = "PH", Mínimo = 6.5f, Máximo = 8.5f},

                //Entidad Filtro Carbon Activado - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 30, Descripción = "Cloro Residual", Mínimo = 0, Máximo = 0.05f},
            new Parametros() {ParametroId = 31, Descripción = "Color", Mínimo = 5, Máximo = 15},
            new Parametros() {ParametroId = 32, Descripción = "Turbidez", Mínimo = 10, Máximo = 25},
            new Parametros() {ParametroId = 33, Descripción = "Olor", Mínimo = 0, Máximo = 1},

                //Entidad Ablandadores - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 40, Descripción = "Dureza", Mínimo = 0, Máximo = 500},
            new Parametros() {ParametroId = 41, Descripción = "STD", Mínimo = 70, Máximo = 1000},
            new Parametros() {ParametroId = 42, Descripción = "PH", Mínimo = 6.5f, Máximo = 8.5f},

                //Entidad Osmosis - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 50, Descripción = "PH", Mínimo = 6.5f, Máximo = 8.5f},
            new Parametros() {ParametroId = 51, Descripción = "STD", Mínimo = 2, Máximo = 500},});

            modelBuilder.Entity<EntidadesMuestreoAgua>().HasData(new List<EntidadesMuestreoAgua>()
            {
                //Entidades de muestreo de agua
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 1, Descripción = "Cisterna 1"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 2, Descripción = "Cisterna 2"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 3, Descripción = "Cisterna 3"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 4, Descripción = "INAPA"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 5, Descripción = "Filtro Carbón Activado"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 6, Descripción = "Ablandadores"},
            new EntidadesMuestreoAgua() {EntidadesMuestreoAguaId = 7, Descripción = "Ósmosis"},});
        }

        public DbSet<EntidadesMuestreoAgua> EntidadesMuestreoAgua { get; set; } = default!;
    }
}


