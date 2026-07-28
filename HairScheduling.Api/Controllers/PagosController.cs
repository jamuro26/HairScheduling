using HairScheduling.Data;
using HairScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HairScheduling.Api.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly HairSchedulingDbContext _context;

        public PagosController(HairSchedulingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pago>>> GetAll()
        {
            return await _context.Pagos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetById(int id)
        {
            var item = await _context.Pagos.FindAsync(id);
            if (item is null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> Create(Pago item)
        {
            _context.Pagos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pago item)
        {
            if (id != item.Id) return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            var existe = await _context.Pagos.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Pagos.FindAsync(id);
            if (item is null) return NotFound();

            _context.Pagos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
