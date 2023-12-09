using AguaMariaSolutionsDoNet8.Data;
using AguaMariaSolutionsDoNet8.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AguaMariaSolutionsDoNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosCreadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParametrosCreadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParametrosCreados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametrosCreados>>> GetParametrosCreados()
        {
            if (_context.ParametrosCreados == null)
            {
                return NotFound();
            }
            return await _context.ParametrosCreados.ToListAsync();
        }

        // GET: api/ParametrosCreados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametrosCreados>> GetParametrosCreados(int id)
        {
            if (_context.ParametrosCreados == null)
            {
                return NotFound();
            }
            var parametrosCreados = await _context.ParametrosCreados.FindAsync(id);

            if (parametrosCreados == null)
            {
                return NotFound();
            }

            return parametrosCreados;
        }

        // PUT: api/ParametrosCreados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametrosCreados(int id, ParametrosCreados parametrosCreados)
        {
            if (id != parametrosCreados.CreadoId)
            {
                return BadRequest();
            }

            _context.Entry(parametrosCreados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametrosCreadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ParametrosCreados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametrosCreados>> PostParametrosCreados(ParametrosCreados parametrosCreados)
        {
            if (_context.ParametrosCreados == null)
            {
                return Problem("Entity set 'Contexto.ParametrosCreados'  is null.");
            }
            _context.ParametrosCreados.Add(parametrosCreados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametrosCreados", new { id = parametrosCreados.CreadoId }, parametrosCreados);
        }

        // DELETE: api/ParametrosCreados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametrosCreados(int id)
        {
            if (_context.ParametrosCreados == null)
            {
                return NotFound();
            }
            var parametrosCreados = await _context.ParametrosCreados.FindAsync(id);
            if (parametrosCreados == null)
            {
                return NotFound();
            }

            _context.ParametrosCreados.Remove(parametrosCreados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametrosCreadosExists(int id)
        {
            return (_context.ParametrosCreados?.Any(e => e.CreadoId == id)).GetValueOrDefault();
        }
    }
}
