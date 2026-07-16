using Microsoft.EntityFrameworkCore;
using HairScheduling.Models;

namespace HairScheduling.Data
{
    public class HairSchedulingDbContext : DbContext
    {
        public HairSchedulingDbContext(DbContextOptions<HairSchedulingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleCita> DetallesCitas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
