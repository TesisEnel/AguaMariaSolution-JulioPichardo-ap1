using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AguaMariaSolution.Shared.Models
{
    public class ControlCalidadAgua
    {
        [Key]
        public int ControlCalidadAguaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [StringLength(500, ErrorMessage = "No puede exceder los 500 caracteres")]

        public string? AcciónTomada { get; set; }

        public int EmpleadoId { get; set; }

        public int EntidadMuestreoAguaId { get; set; }

        public int TandaId { get; set; }

        [ForeignKey("ControlCalidadAguaId")]
        public ICollection<ControlCalidadAguaDetalle> ControlCalidadAguaDetalle { get; set; } = new List<ControlCalidadAguaDetalle>();
    }
}
