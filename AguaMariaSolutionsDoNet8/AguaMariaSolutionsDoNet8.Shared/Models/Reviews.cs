using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        public int ClienteId { get; set; }

        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un comentario")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una valoración")]
        [Range(1, 10, ErrorMessage = "La valoración debe ser entre 1 y 10")]
        public int Valoración { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Por favor ingrese una valoración")]
        public DateTime FechaDeBotellon{ get; set; } = DateTime.Now;
    }
}
