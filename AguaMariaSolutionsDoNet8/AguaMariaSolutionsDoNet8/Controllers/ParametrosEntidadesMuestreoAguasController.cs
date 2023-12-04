using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AguaMariaSolutionsDoNet8.Data;
using AguaMariaSolutionsDoNet8.Shared.Models;

namespace AguaMariaSolutionsDoNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosEntidadesMuestreoAguasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParametrosEntidadesMuestreoAguasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParametrosEntidadesMuestreoAguas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametrosEntidadesMuestreoAguas>>> GetParametrosEntidadesMuestreoAguas_1()
        {
          if (_context.ParametrosEntidadesMuestreoAguas == null)
          {
              return NotFound();
          }
            return await _context.ParametrosEntidadesMuestreoAguas.ToListAsync();
        }

        // GET: api/ParametrosEntidadesMuestreoAguas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametrosEntidadesMuestreoAguas>> GetParametrosEntidadesMuestreoAguas(int id)
        {
          if (_context.ParametrosEntidadesMuestreoAguas == null)
          {
              return NotFound();
          }
            var parametrosEntidadesMuestreoAguas = await _context.ParametrosEntidadesMuestreoAguas.FindAsync(id);

            if (parametrosEntidadesMuestreoAguas == null)
            {
                return NotFound();
            }

            return parametrosEntidadesMuestreoAguas;
        }

        // PUT: api/ParametrosEntidadesMuestreoAguas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametrosEntidadesMuestreoAguas(int id, ParametrosEntidadesMuestreoAguas parametrosEntidadesMuestreoAguas)
        {
            if (id != parametrosEntidadesMuestreoAguas.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametrosEntidadesMuestreoAguas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametrosEntidadesMuestreoAguasExists(id))
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

        // POST: api/ParametrosEntidadesMuestreoAguas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametrosEntidadesMuestreoAguas>> PostParametrosEntidadesMuestreoAguas(ParametrosEntidadesMuestreoAguas parametrosEntidadesMuestreoAguas)
        {
          if (_context.ParametrosEntidadesMuestreoAguas == null)
          {
              return Problem("Entity set 'Contexto.ParametrosEntidadesMuestreoAguas'  is null.");
          }
            _context.ParametrosEntidadesMuestreoAguas.Add(parametrosEntidadesMuestreoAguas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametrosEntidadesMuestreoAguas", new { id = parametrosEntidadesMuestreoAguas.Id }, parametrosEntidadesMuestreoAguas);
        }

        // DELETE: api/ParametrosEntidadesMuestreoAguas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametrosEntidadesMuestreoAguas(int id)
        {
            if (_context.ParametrosEntidadesMuestreoAguas == null)
            {
                return NotFound();
            }
            var parametrosEntidadesMuestreoAguas = await _context.ParametrosEntidadesMuestreoAguas.FindAsync(id);
            if (parametrosEntidadesMuestreoAguas == null)
            {
                return NotFound();
            }

            _context.ParametrosEntidadesMuestreoAguas.Remove(parametrosEntidadesMuestreoAguas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametrosEntidadesMuestreoAguasExists(int id)
        {
            return (_context.ParametrosEntidadesMuestreoAguas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
