#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models
{
    [Table("Fact_Encabezado")]
    public class Fact_Encabezado
    {
        [Key]
        public int FEnc_ID { get; set; }

        // 🔹obliga a asignar valor (disponible desde C# 11)
        [Required, MaxLength(50, ErrorMessage = "El número de factura no puede tener más de 50 caracteres.")]
        public required string FEnc_Numero { get; set; }

        // 🔹 Fecha se inicializa automáticamente al crear la factura
        public DateTime FEnc_Fecha { get; set; } = DateTime.Now;

        // 🔹 Llave hacia Persona
        [ForeignKey("Persona")]
        public int zPer_ID { get; set; }
        public Persona? Persona { get; set; }

        // 🔹 Relación con los detalles de la factura
        public ICollection<Fact_Detalle>? Detalles { get; set; }
    }
}
