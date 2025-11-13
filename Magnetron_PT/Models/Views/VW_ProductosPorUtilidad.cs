using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models.Views
{
    [Keyless]
    [Table("VW_Productos_UtilidadGenerada")]
    public class VW_ProductosPorUtilidad
    {
        public string Prod_Descripcion { get; set; }
        public decimal UtilidadGenerada { get; set; }
    }
}
