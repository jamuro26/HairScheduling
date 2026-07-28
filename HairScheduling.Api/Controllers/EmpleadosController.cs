using HairScheduling.Data;
using HairScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HairScheduling.Api.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly HairSchedulingDbContext _context;

        public EmpleadosController(HairSchedulingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetAll()
        {
            return await _context.Empleados.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {
            var item = await _context.Empleados.FindAsync(id);
            if (item is null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> Create(Empleado item)
        {
            _context.Empleados.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Empleado item)
        {
            if (id != item.Id) return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            var existe = await _context.Empleados.AnyAsync(x => x.Id == id);
            if (!existe) return NotFound();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Empleados.FindAsync(id);
            if (item is null) return NotFound();

            _context.Empleados.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
