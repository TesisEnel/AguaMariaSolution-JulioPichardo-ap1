using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Dirección { get; set; }

        [ForeignKey("EmpleadoId")]
        public ICollection<ControlCalidadProductoTerminado> ControlCalidadProductoTerminado { get; set; } = new List<ControlCalidadProductoTerminado>();
    }
}
