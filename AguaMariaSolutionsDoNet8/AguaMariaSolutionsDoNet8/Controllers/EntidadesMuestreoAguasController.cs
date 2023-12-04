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
    public class EntidadesMuestreoAguasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntidadesMuestreoAguasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntidadesMuestreoAguas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntidadesMuestreoAguas>>> GetEntidadesMuestreoAgua()
        {
            if (_context.EntidadesMuestreoAguas == null)
            {
                return NotFound();
            }
            return await _context.EntidadesMuestreoAguas
                            .Include(e => e.ListaParametros)
                            .ToListAsync();
        }

        // GET: api/EntidadesMuestreoAguas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadesMuestreoAguas>> GetEntidadesMuestreoAgua(int id)
        {
            if (_context.EntidadesMuestreoAguas == null)
            {
                return NotFound();
            }
            var EntidadesMuestreoAguas = await _context.EntidadesMuestreoAguas
                                                        .Include(e => e.ListaParametros)
                                                        .Where(e => e.EntidadesMuestreoAguaId == id)
                                                        .FirstOrDefaultAsync(); ;
            if (EntidadesMuestreoAguas == null)
            {
                return NotFound();
            }

            return EntidadesMuestreoAguas;
        }

        // PUT: api/EntidadesMuestreoAguas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidadesMuestreoAgua(int id, EntidadesMuestreoAguas entidadesMuestreoAguas)
        {
            if (id != entidadesMuestreoAguas.EntidadesMuestreoAguaId)
            {
                return BadRequest();
            }

            _context.Entry(entidadesMuestreoAguas).State = EntityState.Modified;

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
        public async Task<ActionResult<EntidadesMuestreoAguas>> PostEntidadesMuestreoAgua(EntidadesMuestreoAguas entidadesMuestreoAguas)
        {
            if (!EntidadesMuestreoAguaExists(entidadesMuestreoAguas.EntidadesMuestreoAguaId))
                _context.EntidadesMuestreoAguas.Add(entidadesMuestreoAguas);
            else
                _context.EntidadesMuestreoAguas.Update(entidadesMuestreoAguas);
            await _context.SaveChangesAsync();
            return Ok(entidadesMuestreoAguas);
        }

        // DELETE: api/EntidadesMuestreoAguas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidadesMuestreoAgua(int id)
        {
            try
            {
                var entidadesMuestreoAguas = await _context.EntidadesMuestreoAguas
                    .Include(e => e.ListaParametros)
                    .FirstOrDefaultAsync(e => e.EntidadesMuestreoAguaId == id);

                if (entidadesMuestreoAguas == null)
                {
                    return NotFound();
                }

                // Delete related records in ParametrosEntidadesMuestreoAguas
                foreach (var detalle in entidadesMuestreoAguas.ListaParametros)
                {
                    _context.ParametrosEntidadesMuestreoAguas.Remove(detalle);
                }

                // Delete the main record in EntidadesMuestreoAguas
                _context.EntidadesMuestreoAguas.Remove(entidadesMuestreoAguas);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



        private bool EntidadesMuestreoAguaExists(int id)
        {
            return (_context.EntidadesMuestreoAguas?.Any(e => e.EntidadesMuestreoAguaId == id)).GetValueOrDefault();
        }
    }
}
