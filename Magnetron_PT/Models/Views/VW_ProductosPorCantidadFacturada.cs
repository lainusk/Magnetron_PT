using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models.Views
{
    [Keyless]
    [Table("VW_Productos_CantidadFacturada")]
    public class VW_ProductosPorCantidadFacturada
    {
        public string Prod_Descripcion { get; set; }
        public decimal CantidadFacturada { get; set; }
    }
}
