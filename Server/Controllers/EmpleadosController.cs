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
    public class EmpleadosController : ControllerBase
    {
        private readonly Contexto _context;

        public EmpleadosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleados(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleados = await _context.Empleados.FindAsync(id);

            if (empleados == null)
            {
                return NotFound();
            }

            return empleados;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleados(int id, Empleados empleados)
        {
            if (id != empleados.EmpleadoId)
            {
                return BadRequest();
            }

            _context.Entry(empleados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
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

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleados(Empleados empleados)
        {
            if (!EmpleadosExists(empleados.EmpleadoId))
                _context.Empleados.Add(empleados);
            else
                _context.Empleados.Update(empleados);

            await _context.SaveChangesAsync();
            return Ok(empleados);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadosExists(int id)
        {
            return (_context.Empleados?.Any(e => e.EmpleadoId == id)).GetValueOrDefault();
        }
    }
}
