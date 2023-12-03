using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AguaMariaSolution.Server.DAL;
using AguaMariaSolution.Shared.Models;

namespace AguaMariaSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlCalidadProductoTerminadoController : ControllerBase
    {
        private readonly Contexto _context;

        public ControlCalidadProductoTerminadoController(Contexto context)
        {
            _context = context;
        }

        // GET: api/ControlCalidadProductoTerminado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlCalidadProductoTerminado>>> GetControlCalidadProductoTerminado()
        {
          if (_context.ControlCalidadProductoTerminado == null)
          {
              return NotFound();
          }
            return await _context.ControlCalidadProductoTerminado.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ControlCalidadProductoTerminado>> GetControlCalidadProductoTerminado(int id)
        {
            if (_context.ControlCalidadProductoTerminado == null)
            {
                return NotFound();
            }
            var controlCalidadProductoTerminado = await _context.ControlCalidadProductoTerminado
                .Include(c => c.ProductoTerminadosDetalle)
                .Where(c => c.ProductoTerminadoId == id)
                .FirstOrDefaultAsync();

            if (controlCalidadProductoTerminado == null)
            {
                return NotFound();
            }

            return controlCalidadProductoTerminado;
        }

        // PUT: api/ControlCalidadProductoTerminado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlCalidadProductoTerminado(int id, ControlCalidadProductoTerminado controlCalidadProductoTerminado)
        {
            if (id != controlCalidadProductoTerminado.ProductoTerminadoId)
            {
                return BadRequest();
            }

            _context.Entry(controlCalidadProductoTerminado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlCalidadProductoTerminadoExists(id))
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

        // POST: api/ControlCalidadProductoTerminado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ControlCalidadProductoTerminado>> PostControlCalidadProductoTerminado(ControlCalidadProductoTerminado controlCalidadProductoTerminado)
        {
            if (!ControlCalidadProductoTerminadoExists(controlCalidadProductoTerminado.ProductoTerminadoId))
                _context.ControlCalidadProductoTerminado.Add(controlCalidadProductoTerminado);
            else
                _context.ControlCalidadProductoTerminado.Update(controlCalidadProductoTerminado);

            await _context.SaveChangesAsync();
            return Ok(controlCalidadProductoTerminado);
        }

        // DELETE: api/ControlCalidadProductoTerminado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlCalidadProductoTerminado(int id)
        {
            if (_context.ControlCalidadProductoTerminado == null)
            {
                return NotFound();
            }
            var controlCalidadProductoTerminado = await _context.ControlCalidadProductoTerminado.FindAsync(id);
            if (controlCalidadProductoTerminado == null)
            {
                return NotFound();
            }

            _context.ControlCalidadProductoTerminado.Remove(controlCalidadProductoTerminado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteDetalles/{id}")]
        public async Task<IActionResult> DeleteDetalles(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var productosT = await _context.ProductoTerminadosDetalle.FirstOrDefaultAsync(pt => pt.DetalleId == id);
            if (productosT is null)
            {
                return NotFound();
            }
            _context.ProductoTerminadosDetalle.Remove(productosT);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ControlCalidadProductoTerminadoExists(int id)
        {
            return (_context.ControlCalidadProductoTerminado?.Any(e => e.ProductoTerminadoId == id)).GetValueOrDefault();
        }

        [HttpGet("GetUltimoDocumento")]
        public async Task<ActionResult<ControlCalidadProductoTerminado>> GetUltimoDocumento()
        {
            if (!_context.ControlCalidadProductoTerminado.Any())
            {
                return NotFound();
            }

            var ControlCalidadProductoTerminado = _context.ControlCalidadProductoTerminado
                        .Include(c => c.ProductoTerminadosDetalle)
                        .OrderByDescending(c => c.Fecha).Take(1).FirstOrDefault();

            if (ControlCalidadProductoTerminado == null)
            {
                return NotFound();
            }

            if (ControlCalidadProductoTerminado.Fecha.Date == DateTime.Now.Date)
            {
                return ControlCalidadProductoTerminado;
            }

            return NotFound();
        }
    }
}
