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
    public class ControlCalidadAguasController : ControllerBase
    {
        private readonly Contexto _context;

        public ControlCalidadAguasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/ControlCalidadAguas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlCalidadAgua>>> GetControlCalidadAgua()
        {
          if (_context.ControlCalidadAgua == null)
          {
              return NotFound();
          }
            return await _context.ControlCalidadAgua.ToListAsync();
        }

        // GET: api/ControlCalidadAguas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlCalidadAgua>> GetControlCalidadAgua(int id)
        {
          if (_context.ControlCalidadAgua == null)
          {
              return NotFound();
          }
            var controlCalidadAgua = await _context.ControlCalidadAgua
                .Include(c => c.ControlCalidadAguaDetalle)
                .Where(c => c.ControlCalidadAguaId == id)
                .FirstOrDefaultAsync();

            if (controlCalidadAgua == null)
            {
                return NotFound();
            }

            return controlCalidadAgua;
        }

        // PUT: api/ControlCalidadAguas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlCalidadAgua(int id, ControlCalidadAgua controlCalidadAgua)
        {
            if (id != controlCalidadAgua.ControlCalidadAguaId)
            {
                return BadRequest();
            }

            _context.Entry(controlCalidadAgua).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlCalidadAguaExists(id))
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

        // POST: api/ControlCalidadAguas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ControlCalidadAgua>> PostControlCalidadAgua(ControlCalidadAgua controlCalidadAgua)
        {
            if (!ControlCalidadAguaExists(controlCalidadAgua.ControlCalidadAguaId))
                _context.ControlCalidadAgua.Add(controlCalidadAgua);
            else
                _context.ControlCalidadAgua.Update(controlCalidadAgua);

            await _context.SaveChangesAsync();
            return Ok(controlCalidadAgua);
        }

        // DELETE: api/ControlCalidadAguas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlCalidadAgua(int id)
        {
            if (_context.ControlCalidadAgua == null)
            {
                return NotFound();
            }
            var controlCalidadAgua = await _context.ControlCalidadAgua.FindAsync(id);
            if (controlCalidadAgua == null)
            {
                return NotFound();
            }

            _context.ControlCalidadAgua.Remove(controlCalidadAgua);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ControlCalidadAguaExists(int id)
        {
            return (_context.ControlCalidadAgua?.Any(e => e.ControlCalidadAguaId == id)).GetValueOrDefault();
        }

        [HttpDelete("DeleteAguaDetalle/{id}")]
        public async Task<IActionResult> DeleteAguaDetalle(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Detalle = await _context.ControlCalidadAguaDetalle.FirstOrDefaultAsync(ad => ad.ControlCalidadAguaDetalleId == id);
            if (Detalle is null)
            {
                return NotFound();
            }
            _context.ControlCalidadAguaDetalle.Remove(Detalle);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetUltimoDocumento")]
        public async Task<ActionResult<ControlCalidadAgua>> GetUltimoDocumento()
        {
            if (!_context.ControlCalidadAgua.Any())
            {
                return NotFound();
            }

            var controlCalidadAgua = _context.ControlCalidadAgua
                        .Include(c => c.ControlCalidadAguaDetalle)
                        .OrderByDescending(c => c.Fecha).Take(1).FirstOrDefault();

            if (controlCalidadAgua == null)
            {
                return NotFound();
            }

            if (controlCalidadAgua.Fecha.Date == DateTime.Now.Date)
            {
                return controlCalidadAgua;
            }

            return NotFound();
        }
    }
}
