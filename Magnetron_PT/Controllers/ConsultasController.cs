using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magnetron_PT.Data;
using Magnetron_PT.Models.Views;

namespace Magnetron_PT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly MagnetronDbContext _context;

        public ConsultasController(MagnetronDbContext context)
        {
            _context = context;
        }

        // ================================================
        // 1. Total facturado por persona
        // ================================================
        [HttpGet("TotalFacturadoPorPersona")]
        public async Task<IActionResult> GetTotalFacturadoPorPersona()
        {
            var datos = await _context.Set<VW_TotalFacturadoPorPersona>()
                .OrderByDescending(v => v.TotalFacturado)
                .ToListAsync();

            return Ok(datos);
        }

        // ================================================
        // 2. Persona que compró el producto más caro
        // ================================================
        [HttpGet("PersonaProductoMasCaro")]
        public async Task<IActionResult> GetPersonaProductoMasCaro()
        {
            var datos = await _context.Set<VW_PersonaProductoMasCaro>().ToListAsync();
            return Ok(datos);
        }

        // ================================================
        // 3. Productos por cantidad facturada
        // ================================================
        [HttpGet("ProductosPorCantidadFacturada")]
        public async Task<IActionResult> GetProductosPorCantidadFacturada()
        {
            var datos = await _context.Set<VW_ProductosPorCantidadFacturada>()
                .OrderByDescending(v => v.CantidadFacturada)
                .ToListAsync();

            return Ok(datos);
        }

        // ================================================
        // 4. Productos por utilidad generada
        // ================================================
        [HttpGet("ProductosPorUtilidad")]
        public async Task<IActionResult> GetProductosPorUtilidad()
        {
            var datos = await _context.Set<VW_ProductosPorUtilidad>()
                .OrderByDescending(v => v.UtilidadGenerada)
                .ToListAsync();

            return Ok(datos);
        }

        // ================================================
        // 5. Margen de ganancia por producto
        // ================================================
        [HttpGet("MargenDeGananciaPorProducto")]
        public async Task<IActionResult> GetMargenDeGananciaPorProducto()
        {
            var datos = await _context.Set<VW_MargenDeGananciaPorProducto>()
                .OrderByDescending(v => v.MargenGananciaPorcentaje)
                .ToListAsync();

            return Ok(datos);
        }
    }
}
