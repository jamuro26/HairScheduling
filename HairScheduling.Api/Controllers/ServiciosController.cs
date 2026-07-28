using HairScheduling.Data;
using HairScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HairScheduling.Api.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class ServiciosController : ControllerBase
    {
        private readonly HairSchedulingDbContext _context;

        public ServiciosController(HairSchedulingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> GetAll()
        {
            return await _context.Servicios.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetById(int id)
        {
            var item = await _context.Servicios.FindAsync(id);
            if (item is null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Servicio>> Create(Servicio item)
        {
            _context.Servicios.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Servicio item)
        {
            if (id != item.Id) return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            var existe = await _context.Servicios.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Servicios.FindAsync(id);
            if (item is null) return NotFound();

            _context.Servicios.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
