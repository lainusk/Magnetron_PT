using Microsoft.EntityFrameworkCore;
using Magnetron_PT.Models;
using Magnetron_PT.Models.Views;

namespace Magnetron_PT.Data
{
    public class MagnetronDbContext : DbContext
    {
        public MagnetronDbContext(DbContextOptions<MagnetronDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Fact_Encabezado> Fact_Encabezado { get; set; }
        public DbSet<Fact_Detalle> Fact_Detalle { get; set; }
        public DbSet<VW_TotalFacturadoPorPersona> VW_TotalFacturadoPorPersona { get; set; }
        public DbSet<VW_PersonaProductoMasCaro> VW_Persona_ProductoMasCaro { get; set; }
        public DbSet<VW_ProductosPorCantidadFacturada> VW_Productos_CantidadFacturada { get; set; }
        public DbSet<VW_ProductosPorUtilidad> VW_Productos_UtilidadGenerada { get; set; }
        public DbSet<VW_MargenDeGananciaPorProducto> VW_Productos_MargenGanancia { get; set; }

    }
}
