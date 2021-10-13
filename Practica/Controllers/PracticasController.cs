using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Data;
using Practica.Models;

namespace Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PracticasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Practicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practicas>>> GetPractica()
        {
            return await _context.Practica.ToListAsync();
        }

        // GET: api/Practicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practicas>> GetPracticas(int id)
        {
            var practicas = await _context.Practica.FindAsync(id);

            if (practicas == null)
            {
                return NotFound();
            }

            return practicas;
        }

        // PUT: api/Practicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracticas(int id, Practicas practicas)
        {
            if (id != practicas.NameId)
            {
                return BadRequest();
            }

            _context.Entry(practicas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticasExists(id))
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

        // POST: api/Practicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Practicas>> PostPracticas(Practicas practicas)
        {
            _context.Practica.Add(practicas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPracticas", new { id = practicas.NameId }, practicas);
        }

        // DELETE: api/Practicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracticas(int id)
        {
            var practicas = await _context.Practica.FindAsync(id);
            if (practicas == null)
            {
                return NotFound();
            }

            _context.Practica.Remove(practicas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracticasExists(int id)
        {
            return _context.Practica.Any(e => e.NameId == id);
        }
    }
}
