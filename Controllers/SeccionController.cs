using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventApi.Data;
using EventApi.Models;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : ControllerBase
    {
        private readonly Contexto _context;

        public SeccionController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Seccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seccion>>> GetSeccion()
        {
            return await _context.Seccion.ToListAsync();
        }

        // GET: api/Seccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seccion>> GetSeccion(int id)
        {
            var Seccion = await _context.Seccion.FindAsync(id);

            if (Seccion == null)
            {
                return NotFound();
            }

            return Seccion;
        }

        // PUT: api/Seccion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeccion(int id, Seccion Seccion)
        {
            if (id != Seccion.SeccionId)
            {
                return BadRequest();
            }

            _context.Entry(Seccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccionExists(id))
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

        // POST: api/Seccion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seccion>> PostSeccion(Seccion Seccion)
        {
            _context.Seccion.Add(Seccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeccion", new { id = Seccion.SeccionId }, Seccion);
        }

        // DELETE: api/Seccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeccion(int id)
        {
            var Seccion = await _context.Seccion.FindAsync(id);
            if (Seccion == null)
            {
                return NotFound();
            }

            _context.Seccion.Remove(Seccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeccionExists(int id)
        {
            return _context.Seccion.Any(e => e.SeccionId== id);
        }
    }
}
