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
    public class ReferenciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReferenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Referencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Referencias>>> GetReferencias()
        {
          if (_context.Referencias == null)
          {
              return NotFound();
          }
            return await _context.Referencias.ToListAsync();
        }

        // GET: api/Referencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Referencias>> GetReferencias(int id)
        {
          if (_context.Referencias == null)
          {
              return NotFound();
          }
            var referencias = await _context.Referencias.FindAsync(id);

            if (referencias == null)
            {
                return NotFound();
            }

            return referencias;
        }

        // PUT: api/Referencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferencias(int id, Referencias referencias)
        {
            if (id != referencias.ReferenciaId)
            {
                return BadRequest();
            }

            _context.Entry(referencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenciasExists(id))
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

        // POST: api/Referencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Referencias>> PostReferencias(Referencias referencias)
        {
            if (!ReferenciasExists(referencias.ReferenciaId))
                _context.Referencias.Add(referencias);
            else
                _context.Referencias.Update(referencias);
            await _context.SaveChangesAsync();
            return Ok(referencias);
        }

        // DELETE: api/Referencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencias(int id)
        {
            if (_context.Referencias == null)
            {
                return NotFound();
            }
            var referencias = await _context.Referencias.FindAsync(id);
            if (referencias == null)
            {
                return NotFound();
            }

            _context.Referencias.Remove(referencias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenciasExists(int id)
        {
            return (_context.Referencias?.Any(e => e.ReferenciaId == id)).GetValueOrDefault();
        }
    }
}
