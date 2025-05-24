using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventos.Modelos;

namespace GestionEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonenteEventosController : ControllerBase
    {
        private readonly AppGestionEventosDbContext _context;

        public PonenteEventosController(AppGestionEventosDbContext context)
        {
            _context = context;
        }

        // GET: api/PonenteEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PonenteEvento>>> GetPonenteEvento()
        {
            return await _context.PonenteEventos
                        .Include(l => l.Evento)
                        .Include(l => l.Ponente)
                        .ToListAsync();
        }

        // GET: api/PonenteEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PonenteEvento>> GetPonenteEvento(int id)
        {
            var ponenteEvento = await _context.PonenteEventos.FindAsync(id);

            if (ponenteEvento == null)
            {
                return NotFound();
            }

            return ponenteEvento;
        }

        // PUT: api/PonenteEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonenteEvento(int id, PonenteEvento ponenteEvento)
        {
            if (id != ponenteEvento.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(ponenteEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonenteEventoExists(id))
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

        // POST: api/PonenteEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PonenteEvento>> PostPonenteEvento(PonenteEvento ponenteEvento)
        {
            _context.PonenteEventos.Add(ponenteEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPonenteEvento", new { id = ponenteEvento.Codigo }, ponenteEvento);
        }

        // DELETE: api/PonenteEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonenteEvento(int id)
        {
            var ponenteEvento = await _context.PonenteEventos.FindAsync(id);
            if (ponenteEvento == null)
            {
                return NotFound();
            }

            _context.PonenteEventos.Remove(ponenteEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PonenteEventoExists(int id)
        {
            return _context.PonenteEventos.Any(e => e.Codigo == id);
        }
    }
}
