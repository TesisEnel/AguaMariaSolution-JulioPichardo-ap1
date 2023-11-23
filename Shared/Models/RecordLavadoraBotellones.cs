using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class RecordLavadoraBotellones
    {
        [Key]
        public int RecordId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public float Temperatura { get; set; }
        public float Detergente { get; set; }
        public string? AlcalinidadEnjuague { get; set; }
        public string? DesinfectanteConcentración { get; set; }
        public int ClienteId { get; set; }
        public string? AcciónTomada { get; set; }
    }
}
