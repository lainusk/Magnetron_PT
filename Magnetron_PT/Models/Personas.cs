using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int Per_ID { get; set; }

        [Required, MaxLength(100)]
        public string Per_Nombre { get; set; }

        [Required, MaxLength(100)]
        public string Per_Apellido { get; set; }

        [Required, MaxLength(20)]
        public string Per_TipoDocumento { get; set; }

        [Required, MaxLength(50)]
        public string Per_Documento { get; set; }
    }
}
