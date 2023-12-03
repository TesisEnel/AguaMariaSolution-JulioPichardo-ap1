using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolution.Shared.Models
{
    public class Referencias
    {
        [Key]
        public int ReferenciaId { get; set; }

        [ForeignKey("ParametroId")]
        public int ParametroId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripción { get; set; }
    }
}
        
