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
    public class EventoController : ControllerBase
    {
        private readonly Contexto _context;

        public EventoController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEvento()
        {
            return await _context.Evento.ToListAsync();
        }

        // GET: api/Evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var Evento = await _context.Evento.FindAsync(id);

            if (Evento == null)
            {
                return NotFound();
            }

            return Evento;
        }

        // PUT: api/Evento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento Evento)
        {
            if (id != Evento.EventoId)
            {
                return BadRequest();
            }

            _context.Entry(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Evento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento Evento)
        {
            _context.Evento.Add(Evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = Evento.EventoId }, Evento);
        }

        // DELETE: api/Evento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var Evento = await _context.Evento.FindAsync(id);
            if (Evento == null)
            {
                return NotFound();
            }

            _context.Evento.Remove(Evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.EventoId== id);
        }
    }
}
