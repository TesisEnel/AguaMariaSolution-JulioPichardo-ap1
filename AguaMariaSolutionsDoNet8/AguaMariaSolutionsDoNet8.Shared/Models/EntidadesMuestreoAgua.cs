using System.ComponentModel.DataAnnotations;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class EntidadesMuestreoAgua
    {
        [Key]
        public int EntidadesMuestreoAguaId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripción { get; set; }
    }
}
