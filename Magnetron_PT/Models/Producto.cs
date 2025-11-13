#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int Prod_ID { get; set; }

        // 🔹 Descripción obligatoria y con longitud máxima
        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres.")]
        public required string Prod_Descripcion { get; set; }

        // 🔹 Precio debe ser mayor que 0
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Prod_Precio { get; set; }

        // 🔹 Costo no puede ser negativo
        [Range(0.0, double.MaxValue, ErrorMessage = "El costo no puede ser negativo.")]
        public decimal Prod_Costo { get; set; }

        // 🔹 Unidad de medida opcional, pero con límite de 20 caracteres
        [MaxLength(20)]
        public string? Prod_UM { get; set; }
    }
}
