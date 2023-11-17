using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del cliente")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del cliente")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del cliente")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string? Email { get; set; }

        [ForeignKey("ClienteId")]
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    }
}
