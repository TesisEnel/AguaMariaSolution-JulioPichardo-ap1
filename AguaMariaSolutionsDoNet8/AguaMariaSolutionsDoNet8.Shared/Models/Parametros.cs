using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class Parametros
    {
        [Key]
        public int ParametroId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la descripción del Parametro")]
        public string? Descripción { get; set; }

        [Required(ErrorMessage = "Debe introducir el mínimo")]
        public float Mínimo { get; set; }

        [Required(ErrorMessage = "Debe introducir el máximo")]
        public float Máximo { get; set; }
    }
}
