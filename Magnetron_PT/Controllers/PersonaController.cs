using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Magnetron_PT.Data;
using Magnetron_PT.Models;

namespace Magnetron_PT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly MagnetronDbContext _context;

        public PersonaController(MagnetronDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            try
            {
                var personas = await _context.Persona.ToListAsync();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error de conexión: {ex.Message}");
            }
        }

       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

           
            var exists = await _context.Persona.AnyAsync(p => p.Per_Documento == persona.Per_Documento);
            if (exists) return Conflict($"Ya existe una persona con documento '{persona.Per_Documento}'.");

            _context.Persona.Add(persona);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al insertar: {dbEx.Message}");
            }

            return CreatedAtAction(nameof(GetPersona), new { id = persona.Per_ID }, persona);
        }

      
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.Per_ID) return BadRequest("El id de la URL no coincide con el cuerpo de la petición.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

           
            var other = await _context.Persona
                .FirstOrDefaultAsync(p => p.Per_Documento == persona.Per_Documento && p.Per_ID != id);
            if (other != null) return Conflict($"El documento '{persona.Per_Documento}' ya pertenece a otra persona.");

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Persona.AnyAsync(p => p.Per_ID == id)) return NotFound();
                throw;
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al actualizar: {dbEx.Message}");
            }
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null) return NotFound();

            _context.Persona.Remove(persona);
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
