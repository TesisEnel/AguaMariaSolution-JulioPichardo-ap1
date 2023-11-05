using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    internal class Parametros
    {
        [Key]
        int ParametroId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la descripción del Parametro")]
        string Descripción { get; set; }

        [Required(ErrorMessage = "Debe introducir el mínimo")]
        int Mínimo { get; set; }

        [Required(ErrorMessage = "Debe introducir el máximo")]
        int Máximo { get; set; }
    }
}
