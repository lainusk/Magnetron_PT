#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Magnetron_PT.Models
{
    [Table("Fact_Detalle")]
    public class Fact_Detalle
    {
        [Key]
        public int FDet_ID { get; set; }

        public int FDet_Linea { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public decimal FDet_Cantidad { get; set; }

        [ForeignKey("Producto")]
        public int zProd_ID { get; set; }
        public Producto? Producto { get; set; }

        [ForeignKey("Fact_Encabezado")]
        public int zFEnc_ID { get; set; }

        // 🔹 Evita el ciclo al serializar JSON
        [JsonIgnore]
        public Fact_Encabezado? Fact_Encabezado { get; set; }
    }
}
