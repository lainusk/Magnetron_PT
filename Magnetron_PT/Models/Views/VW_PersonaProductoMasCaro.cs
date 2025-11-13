using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models.Views
{
    [Keyless]
    [Table("VW_Persona_ProductoMasCaro", Schema = "dbo")]
    public class VW_PersonaProductoMasCaro
    {
        public string Per_Nombre { get; set; } = string.Empty;
        public string Per_Apellido { get; set; } = string.Empty;
        public string Prod_Descripcion { get; set; } = string.Empty;
        public decimal PrecioProducto { get; set; }
    }
}

