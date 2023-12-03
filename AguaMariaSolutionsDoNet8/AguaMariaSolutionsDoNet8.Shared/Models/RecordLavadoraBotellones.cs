using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class RecordLavadoraBotellones
    {
        [Key]
        public int RecordId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(120,float.MaxValue,ErrorMessage = "La Temperatura debe ser mayor o igual a 120°F")]
        public float? Temperatura { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public float? Detergente { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? AlcalinidadEnjuague { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public float? DesinfectanteConcentración { get; set; }
        public int EmpleadoId { get; set; }
        public string? AcciónTomada { get; set; }
    }
}
