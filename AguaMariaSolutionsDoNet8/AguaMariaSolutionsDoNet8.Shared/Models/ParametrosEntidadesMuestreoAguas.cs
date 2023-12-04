using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class ParametrosEntidadesMuestreoAguas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EntidadesMuestreoAguaId")]
        public int EntidadesMuestreoAguaId { get; set; }

        [ForeignKey("ParametroId")]
        public int ParametroId { get; set; }
    }
}
