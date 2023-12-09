using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class ParametrosCreados
    {
        [Key]
        public int CreadoId { get; set; }
        public int ParametroId { get; set; }
        public string? Descripción { get; set; }
        public float Mínimo { get; set; }
        public float Máximo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}
