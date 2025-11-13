using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magnetron_PT.Data;
using Magnetron_PT.Models;

namespace Magnetron_PT.Controllers
{
    [Route("api/Consulta_de_Facturas")]
    [ApiController]
    public class Consulta_de_FacturasController : ControllerBase
    {
        private readonly MagnetronDbContext _context;

        public Consulta_de_FacturasController(MagnetronDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/Consulta_de_Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fact_Encabezado>>> GetFacturas()
        {
            var facturas = await _context.Fact_Encabezado
                .Include(f => f.Persona)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Producto)
                .ToListAsync();

            return Ok(facturas);
        }

        // ✅ GET: api/Consulta_de_Facturas/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Fact_Encabezado>> GetFactura(int id)
        {
            var factura = await _context.Fact_Encabezado
                .Include(f => f.Persona)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(f => f.FEnc_ID == id);

            if (factura == null)
                return NotFound($"No se encontró una factura con ID {id}.");

            return Ok(factura);
        }

        // ✅ POST: api/Consulta_de_Facturas
        [HttpPost]
        public async Task<ActionResult<Fact_Encabezado>> PostFactura([FromBody] Fact_Encabezado factura)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var persona = await _context.Persona.FindAsync(factura.zPer_ID);
            if (persona == null)
                return NotFound($"No existe la persona con ID {factura.zPer_ID}.");

            if (factura.Detalles != null && factura.Detalles.Any())
            {
                foreach (var detalle in factura.Detalles)
                {
                    var producto = await _context.Producto.FindAsync(detalle.zProd_ID);
                    if (producto == null)
                        return NotFound($"No existe el producto con ID {detalle.zProd_ID}.");
                }
            }

            _context.Fact_Encabezado.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFactura), new { id = factura.FEnc_ID }, factura);
        }

        // ✅ PUT: api/Consulta_de_Facturas/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutFactura(int id, [FromBody] Fact_Encabezado factura)
        {
            if (id != factura.FEnc_ID)
                return BadRequest("El ID de la factura no coincide con el de la URL.");

            var existente = await _context.Fact_Encabezado
                .Include(f => f.Detalles)
                .FirstOrDefaultAsync(f => f.FEnc_ID == id);

            if (existente == null)
                return NotFound($"No se encontró la factura con ID {id}.");

            existente.FEnc_Numero = factura.FEnc_Numero;
            existente.FEnc_Fecha = factura.FEnc_Fecha;
            existente.zPer_ID = factura.zPer_ID;

            _context.Fact_Detalle.RemoveRange(existente.Detalles);
            if (factura.Detalles != null)
            {
                foreach (var det in factura.Detalles)
                {
                    det.zFEnc_ID = id;
                    _context.Fact_Detalle.Add(det);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ✅ DELETE: api/Consulta_de_Facturas/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _context.Fact_Encabezado
                .Include(f => f.Detalles)
                .FirstOrDefaultAsync(f => f.FEnc_ID == id);

            if (factura == null)
                return NotFound($"No existe la factura con ID {id}.");

            _context.Fact_Encabezado.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/Consulta_de_Facturas/ByNumero/{numero}
        [HttpDelete("ByNumero/{numero}")]
        public async Task<IActionResult> DeleteFacturaPorNumero(string numero)
        {
            var factura = await _context.Fact_Encabezado
                .Include(f => f.Detalles)
                .FirstOrDefaultAsync(f => f.FEnc_Numero == numero);

            if (factura == null)
                return NotFound($"No existe la factura con número '{numero}'.");

            _context.Fact_Encabezado.Remove(factura);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al eliminar la factura: {dbEx.Message}");
            }
        }
    }
}
