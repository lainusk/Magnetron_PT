using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnetron_PT.Models.Views
{
    [Keyless]
    [Table("VW_Productos_MargenGanancia")]
    public class VW_MargenDeGananciaPorProducto
    {
        public string Prod_Descripcion { get; set; }
        public decimal MargenGananciaPorcentaje { get; set; }
    }
}
