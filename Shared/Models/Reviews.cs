using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un comentario")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una valoración")]
        public int Valoración { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del cliente")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del cliente")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del cliente")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string? Email { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
