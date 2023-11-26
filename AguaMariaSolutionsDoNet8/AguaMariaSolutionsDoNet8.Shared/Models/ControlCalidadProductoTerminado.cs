using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class ControlCalidadProductoTerminado
    {
        [Key]
        public int ProductoTerminadoId { get; set; }
        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [StringLength(500,ErrorMessage = "No puede exceder los 500 caracteres")]
        public string? AcciónTomada { get; set; }
        public int EmpleadoId { get; set; }

        [ForeignKey("ProductoTerminadoId")]
        public ICollection<ProductoTerminadosDetalle> ProductoTerminadosDetalle { get; set; } = new List<ProductoTerminadosDetalle>();
    }
}
