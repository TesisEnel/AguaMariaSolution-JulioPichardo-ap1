using System.ComponentModel.DataAnnotations;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class EntidadesMuestreoAguas
    {
        [Key]
        public int EntidadesMuestreoAguaId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripción { get; set; }

        public List<ParametrosEntidadesMuestreoAguas> ListaParametros { get; set; } = new List<ParametrosEntidadesMuestreoAguas>();
    }
}
