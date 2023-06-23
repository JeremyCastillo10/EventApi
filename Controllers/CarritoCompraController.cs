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
    public class CarritoCompraController : ControllerBase
    {
        private readonly Contexto _context;

        public CarritoCompraController(Contexto context)
        {
            _context = context;
        }

        // GET: api/CarritoCompra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoCompra>>> GetCarritoCompra()
        {
            return await _context.CarritoCompra.ToListAsync();
        }

        // GET: api/CarritoCompra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoCompra>> GetCarritoCompra(int id)
        {
            var CarritoCompra = await _context.CarritoCompra.FindAsync(id);

            if (CarritoCompra == null)
            {
                return NotFound();
            }

            return CarritoCompra;
        }

        // PUT: api/CarritoCompra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoCompra(int id, CarritoCompra CarritoCompra)
        {
            if (id != CarritoCompra.CarritoId)
            {
                return BadRequest();
            }

            _context.Entry(CarritoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoCompraExists(id))
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

        // POST: api/CarritoCompra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarritoCompra>> PostCarritoCompra(CarritoCompra CarritoCompra)
        {
            _context.CarritoCompra.Add(CarritoCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarritoCompra", new { id = CarritoCompra.CarritoId }, CarritoCompra);
        }

        // DELETE: api/CarritoCompra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            var CarritoCompra = await _context.CarritoCompra.FindAsync(id);
            if (CarritoCompra == null)
            {
                return NotFound();
            }

            _context.CarritoCompra.Remove(CarritoCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoCompraExists(int id)
        {
            return _context.CarritoCompra.Any(e => e.CarritoId== id);
        }
    }
}
