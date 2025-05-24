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
    public class InformacionesController : ControllerBase
    {
        private readonly AppGestionEventosDbContext _context;

        public InformacionesController(AppGestionEventosDbContext context)
        {
            _context = context;
        }

        // GET: api/Informaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Informacion>>> GetInformacion()
        {
            return await _context.Informaciones
                        .Include(l => l.Participante)
                        .Include(l => l.Evento)
                        .Include(l => l.Pago)
                        .Include(l => l.Certificado)
                        .ToListAsync();

        }

        // GET: api/Informaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Informacion>> GetInformacion(int id)
        {
            var informacion = await _context.Informaciones.FindAsync(id);

            if (informacion == null)
            {
                return NotFound();
            }

            return informacion;
        }

        // PUT: api/Informaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformacion(int id, Informacion informacion)
        {
            if (id != informacion.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(informacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacionExists(id))
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

        // POST: api/Informaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Informacion>> PostInformacion(Informacion informacion)
        {
            _context.Informaciones.Add(informacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformacion", new { id = informacion.Codigo }, informacion);
        }

        // DELETE: api/Informaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformacion(int id)
        {
            var informacion = await _context.Informaciones.FindAsync(id);
            if (informacion == null)
            {
                return NotFound();
            }

            _context.Informaciones.Remove(informacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformacionExists(int id)
        {
            return _context.Informaciones.Any(e => e.Codigo == id);
        }
    }
}
