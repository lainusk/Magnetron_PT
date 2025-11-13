using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models.Views
{
    [Keyless]
    [Table("VW_TotalFacturadoPorPersona")]
    public class VW_TotalFacturadoPorPersona
    {
        public int Per_ID { get; set; }
        public string Per_Nombre { get; set; } = string.Empty;
        public string Per_Apellido { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
    }
}
