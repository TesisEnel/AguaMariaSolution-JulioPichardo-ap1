using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaMariaSolutionsDoNet8.Shared.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="Campo Obligatorio")]
        public string? Nombre { get; set; }
        public byte[]? Imagen { get; set; }

        [ForeignKey("ProductoId")]
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    }
}
