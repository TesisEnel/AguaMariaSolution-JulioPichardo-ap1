using System.ComponentModel.DataAnnotations;

namespace AguaMariaSolution.Shared.Models
{
    public class EntidadesMuestreoAgua
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripción { get; set; }
    }
}
