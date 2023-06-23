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
    public class AsientoController : ControllerBase
    {
        private readonly Contexto _context;

        public AsientoController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Asiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asiento>>> GetAsiento()
        {
            return await _context.Asiento.ToListAsync();
        }

        // GET: api/Asiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asiento>> GetAsiento(int id)
        {
            var Asiento = await _context.Asiento.FindAsync(id);

            if (Asiento == null)
            {
                return NotFound();
            }

            return Asiento;
        }

        // PUT: api/Asiento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsiento(int id, Asiento Asiento)
        {
            if (id != Asiento.AsientoId)
            {
                return BadRequest();
            }

            _context.Entry(Asiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoExists(id))
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

        // POST: api/Asiento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asiento>> PostAsiento(Asiento Asiento)
        {
            _context.Asiento.Add(Asiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsiento", new { id = Asiento.AsientoId }, Asiento);
        }

        // DELETE: api/Asiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsiento(int id)
        {
            var Asiento = await _context.Asiento.FindAsync(id);
            if (Asiento == null)
            {
                return NotFound();
            }

            _context.Asiento.Remove(Asiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsientoExists(int id)
        {
            return _context.Asiento.Any(e => e.AsientoId== id);
        }
    }
}
