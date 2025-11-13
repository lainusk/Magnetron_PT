using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magnetron_PT.Data;
using Magnetron_PT.Models;

namespace Magnetron_PT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly MagnetronDbContext _context;

        public ProductoController(MagnetronDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                var productos = await _context.Producto.ToListAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error de conexión: {ex.Message}");
            }
        }

    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Producto.Add(producto);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProducto), new { id = producto.Prod_ID }, producto);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al insertar: {dbEx.Message}");
            }
        }

      
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] Producto producto)
        {
            if (id != producto.Prod_ID) return BadRequest("El id de la URL no coincide con el cuerpo de la petición.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Producto.AnyAsync(p => p.Prod_ID == id)) return NotFound();
                throw;
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al actualizar: {dbEx.Message}");
            }
        }

   
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Producto.Remove(producto);
            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al eliminar: {dbEx.Message}");
            }
        }
    }
}
