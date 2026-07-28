using HairScheduling.Data;
using HairScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HairScheduling.Api.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitasController : ControllerBase
    {
        private readonly HairSchedulingDbContext _context;

        public CitasController(HairSchedulingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cita>>> GetAll()
        {
            return await _context.Citas.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetById(int id)
        {
            var item = await _context.Citas.FindAsync(id);
            if (item is null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> Create(Cita item)
        {
            _context.Citas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cita item)
        {
            if (id != item.Id) return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            var existe = await _context.Citas.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Citas.FindAsync(id);
            if (item is null) return NotFound();

            _context.Citas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
