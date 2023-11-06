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
    public class EntidadesMuestreoAguasController : ControllerBase
    {
        private readonly Contexto _context;

        public EntidadesMuestreoAguasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/EntidadesMuestreoAguas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadesMuestreoAgua>>> GetEntidadesMuestreoAgua()
        {
          if (_context.EntidadesMuestreoAgua == null)
          {
              return NotFound();
          }
            return await _context.EntidadesMuestreoAgua.ToListAsync();
        }

        // GET: api/EntidadesMuestreoAguas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadesMuestreoAgua>> GetEntidadesMuestreoAgua(int id)
        {
          if (_context.EntidadesMuestreoAgua == null)
          {
              return NotFound();
          }
            var entidadesMuestreoAgua = await _context.EntidadesMuestreoAgua.FindAsync(id);

            if (entidadesMuestreoAgua == null)
            {
                return NotFound();
            }

            return entidadesMuestreoAgua;
        }

        // PUT: api/EntidadesMuestreoAguas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidadesMuestreoAgua(int id, EntidadesMuestreoAgua entidadesMuestreoAgua)
        {
            if (id != entidadesMuestreoAgua.EntidadesMuestreoAguaId)
            {
                return BadRequest();
            }

            _context.Entry(entidadesMuestreoAgua).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadesMuestreoAguaExists(id))
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

        // POST: api/EntidadesMuestreoAguas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntidadesMuestreoAgua>> PostEntidadesMuestreoAgua(EntidadesMuestreoAgua entidadesMuestreoAgua)
        {
          if (_context.EntidadesMuestreoAgua == null)
          {
              return Problem("Entity set 'Contexto.EntidadesMuestreoAgua'  is null.");
          }
            _context.EntidadesMuestreoAgua.Add(entidadesMuestreoAgua);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntidadesMuestreoAgua", new { id = entidadesMuestreoAgua.EntidadesMuestreoAguaId }, entidadesMuestreoAgua);
        }

        // DELETE: api/EntidadesMuestreoAguas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidadesMuestreoAgua(int id)
        {
            if (_context.EntidadesMuestreoAgua == null)
            {
                return NotFound();
            }
            var entidadesMuestreoAgua = await _context.EntidadesMuestreoAgua.FindAsync(id);
            if (entidadesMuestreoAgua == null)
            {
                return NotFound();
            }

            _context.EntidadesMuestreoAgua.Remove(entidadesMuestreoAgua);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntidadesMuestreoAguaExists(int id)
        {
            return (_context.EntidadesMuestreoAgua?.Any(e => e.EntidadesMuestreoAguaId == id)).GetValueOrDefault();
        }
    }
}
