using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class ProductoTerminadosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        
        public int ProductoTerminadoId {  get; set; }

        public int ParametroId { get; set; }

        public float Valor { get; set; }

        public bool Pasó { get; set; }


    }
}
