using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AguaMariaSolutionsDoNet8.Data;
using AguaMariaSolutionsDoNet8.Shared.Models;

namespace AguaMariaSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordLavadoraBotellonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecordLavadoraBotellonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RecordLavadoraBotellones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordLavadoraBotellones>>> GetRecordLavadoraBotellones()
        {
          if (_context.RecordLavadoraBotellones == null)
          {
              return NotFound();
          }
            return await _context.RecordLavadoraBotellones.ToListAsync();
        }

        // GET: api/RecordLavadoraBotellones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordLavadoraBotellones>> GetRecordLavadoraBotellones(int id)
        {
          if (_context.RecordLavadoraBotellones == null)
          {
              return NotFound();
          }
            var recordLavadoraBotellones = await _context.RecordLavadoraBotellones.FindAsync(id);

            if (recordLavadoraBotellones == null)
            {
                return NotFound();
            }

            return recordLavadoraBotellones;
        }

        // PUT: api/RecordLavadoraBotellones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordLavadoraBotellones(int id, RecordLavadoraBotellones recordLavadoraBotellones)
        {
            if (id != recordLavadoraBotellones.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(recordLavadoraBotellones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordLavadoraBotellonesExists(id))
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

        // POST: api/RecordLavadoraBotellones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecordLavadoraBotellones>> PostRecordLavadoraBotellones(RecordLavadoraBotellones recordLavadoraBotellones)
        {
            if (RecordLavadoraBotellonesExists(recordLavadoraBotellones.RecordId))
                _context.RecordLavadoraBotellones.Add(recordLavadoraBotellones);
            else
                _context.RecordLavadoraBotellones.Update(recordLavadoraBotellones);

            await _context.SaveChangesAsync();

            return Ok(recordLavadoraBotellones);
        }

        // DELETE: api/RecordLavadoraBotellones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordLavadoraBotellones(int id)
        {
            if (_context.RecordLavadoraBotellones == null)
            {
                return NotFound();
            }
            var recordLavadoraBotellones = await _context.RecordLavadoraBotellones.FindAsync(id);
            if (recordLavadoraBotellones == null)
            {
                return NotFound();
            }

            _context.RecordLavadoraBotellones.Remove(recordLavadoraBotellones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordLavadoraBotellonesExists(int id)
        {
            return (_context.RecordLavadoraBotellones?.Any(e => e.RecordId == id)).GetValueOrDefault();
        }
    }
}
