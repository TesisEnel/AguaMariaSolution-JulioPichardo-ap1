using AguaMariaSolution.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AguaMariaSolution.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ControlCalidadProductoTerminado> ControlCalidadProductoTerminado { get; set; }
        public DbSet<ProductoTerminadosDetalle> ProductoTerminadosDetalle { get; set; }
        public DbSet<ControlCalidadAgua> ControlCalidadAgua { get; set; }
        public DbSet<ControlCalidadAguaDetalle> ControlCalidadAguaDetalle { get; set; }
        public DbSet<EntidadesMuestreoAguas> EntidadesMuestreoAguas { get; set; }
        public DbSet<ParametrosEntidadesMuestreoAguas> ParametrosEntidadesMuestreoAguas { get; set; }
        public DbSet<Referencias> Referencias { get; set; }

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
            new Parametros() {ParametroId = 120, Descripción = "Cloro Residual", Mínimo = 1, Máximo = 1.5f},
            new Parametros() {ParametroId = 121, Descripción = "Dureza", Mínimo = 68.4f, Máximo = 500},
            new Parametros() {ParametroId = 122, Descripción = "STD", Mínimo = 70, Máximo = 1000},
            new Parametros() {ParametroId = 123, Descripción = "Color", Mínimo = 5, Máximo = 15},
            new Parametros() {ParametroId = 124, Descripción = "Turbidez", Mínimo = 10, Máximo = 25},
            new Parametros() {ParametroId = 125, Descripción = "Sulfato", Mínimo = 250, Máximo = 400},
            new Parametros() {ParametroId = 126, Descripción = "Nitrato", Mínimo = 10, Máximo = 50},

                //Entidad Filtro Carbon Activado - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 130, Descripción = "Cloro Residual", Mínimo = 0, Máximo = 0.05f},
            new Parametros() {ParametroId = 133, Descripción = "Olor", Mínimo = 1, Máximo = 1},

                //Entidad Ablandadores - Registro Control Calidad Del Proceso Del Agua 

                //Entidad Osmosis - Registro Control Calidad Del Proceso Del Agua 
            new Parametros() {ParametroId = 151, Descripción = "STD", Mínimo = 2, Máximo = 500},});

            modelBuilder.Entity<Admins>().HasData(new List<Admins>()
            {
                new Admins() {AdminId = 1, Nombre = "Abraham", Apellido="El Hage Jreij", Email="abrahamehj@ams.com", Contraseña = "Cl@ve123"},
                new Admins() {AdminId = 2, Nombre = "Julio Cesar", Apellido="Pichardo Barranco",Email="juliocpb@ams.com", Contraseña = "Cl@ve123"}
            });

            modelBuilder.Entity<Empleados>().HasData(new List<Empleados>()
            {
                new Empleados() {EmpleadoId = 1, Nombre = "Enel", Apellido="Almonte", Email="elmontee@ams.com", Clave="Cl@ve123", Celular="0123456789", Teléfono="0123456789", Dirección="Su casa"}
            });

            modelBuilder.Entity<EntidadesMuestreoAguas>().HasData(new List<EntidadesMuestreoAguas>()
            {
                //Entidades de muestreo de agua
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 1, Descripción = "Cisterna 1"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 2, Descripción = "Cisterna 2"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 3, Descripción = "Cisterna 3"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 4, Descripción = "INAPA"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 5, Descripción = "Filtro Carbón Activado"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 6, Descripción = "Ablandadores"},
            new EntidadesMuestreoAguas() {EntidadesMuestreoAguaId = 7, Descripción = "Ósmosis"},
            });

            modelBuilder.Entity<ParametrosEntidadesMuestreoAguas>().HasData(
                new ParametrosEntidadesMuestreoAguas { Id = 1, ParametroId = 120, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 2, ParametroId = 121, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 3, ParametroId = 122, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 4, ParametroId = 123, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 5, ParametroId = 124, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 6, ParametroId = 125, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 7, ParametroId = 126, EntidadesMuestreoAguaId = 1 },
                new ParametrosEntidadesMuestreoAguas { Id = 8, ParametroId = 6, EntidadesMuestreoAguaId = 1 },

                new ParametrosEntidadesMuestreoAguas { Id = 9, ParametroId = 120, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 10, ParametroId = 121, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 11, ParametroId = 122, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 12, ParametroId = 123, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 13, ParametroId = 124, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 14, ParametroId = 125, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 15, ParametroId = 126, EntidadesMuestreoAguaId = 2 },
                new ParametrosEntidadesMuestreoAguas { Id = 16, ParametroId = 6, EntidadesMuestreoAguaId = 2 },

                new ParametrosEntidadesMuestreoAguas { Id = 17, ParametroId = 120, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 18, ParametroId = 121, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 19, ParametroId = 122, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 20, ParametroId = 123, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 21, ParametroId = 124, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 22, ParametroId = 125, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 23, ParametroId = 126, EntidadesMuestreoAguaId = 3 },
                new ParametrosEntidadesMuestreoAguas { Id = 24, ParametroId = 6, EntidadesMuestreoAguaId = 3 },

                new ParametrosEntidadesMuestreoAguas { Id = 25, ParametroId = 120, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 26, ParametroId = 121, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 27, ParametroId = 122, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 29, ParametroId = 123, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 30, ParametroId = 124, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 31, ParametroId = 125, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 32, ParametroId = 126, EntidadesMuestreoAguaId = 4 },
                new ParametrosEntidadesMuestreoAguas { Id = 33, ParametroId = 6, EntidadesMuestreoAguaId = 4 },

                new ParametrosEntidadesMuestreoAguas { Id = 34, ParametroId = 130, EntidadesMuestreoAguaId = 5 },
                new ParametrosEntidadesMuestreoAguas { Id = 35, ParametroId = 123, EntidadesMuestreoAguaId = 5 },
                new ParametrosEntidadesMuestreoAguas { Id = 36, ParametroId = 124, EntidadesMuestreoAguaId = 5 },
                new ParametrosEntidadesMuestreoAguas { Id = 37, ParametroId = 133, EntidadesMuestreoAguaId = 5 },

                new ParametrosEntidadesMuestreoAguas { Id = 38, ParametroId = 5, EntidadesMuestreoAguaId = 6 },
                new ParametrosEntidadesMuestreoAguas { Id = 39, ParametroId = 122, EntidadesMuestreoAguaId = 6 },
                new ParametrosEntidadesMuestreoAguas { Id = 40, ParametroId = 6, EntidadesMuestreoAguaId = 6 },

                new ParametrosEntidadesMuestreoAguas { Id = 41, ParametroId = 6, EntidadesMuestreoAguaId = 7 },
                new ParametrosEntidadesMuestreoAguas { Id = 42, ParametroId = 151, EntidadesMuestreoAguaId = 7 }           
            );

            modelBuilder.Entity<Referencias>().HasData(
                new Referencias { ReferenciaId = 1, ParametroId = 1, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 2, ParametroId = 2, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 3, ParametroId = 3, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 4, ParametroId = 5, Descripción = "CaCo3" },
                new Referencias { ReferenciaId = 5, ParametroId = 7, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 6, ParametroId = 8, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 7, ParametroId = 9, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 8, ParametroId = 10, Descripción = "UNID" },
                new Referencias { ReferenciaId = 9, ParametroId = 11, Descripción = "NTU" },
                new Referencias { ReferenciaId = 10, ParametroId = 12, Descripción = "(1) Insipido y (0) Sapido" },
                new Referencias { ReferenciaId = 11, ParametroId = 13, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 12, ParametroId = 14, Descripción = "(1) Sí y (0) no" },
                new Referencias { ReferenciaId = 13, ParametroId = 120, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 14, ParametroId = 121, Descripción = "CaCo3" },
                new Referencias { ReferenciaId = 15, ParametroId = 122, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 16, ParametroId = 123, Descripción = "U. Pt-Co" },
                new Referencias { ReferenciaId = 17, ParametroId = 124, Descripción = "FTU" },
                new Referencias { ReferenciaId = 18, ParametroId = 125, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 19, ParametroId = 126, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 20, ParametroId = 130, Descripción = "mg/L" },
                new Referencias { ReferenciaId = 21, ParametroId = 133, Descripción = "(1) Inodoro y (0) Odoro" },
                new Referencias { ReferenciaId = 22, ParametroId = 151, Descripción = "mg/L" }
            );

        }
    }
}
