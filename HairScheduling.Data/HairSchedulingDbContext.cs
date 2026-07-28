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

            // Cliente 1 -- N Citas
            modelBuilder.Entity<Cita>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empleado 1 -- N Citas
            modelBuilder.Entity<Cita>()
                .HasOne<Empleado>()
                .WithMany()
                .HasForeignKey(c => c.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita 1 -- N DetallesCita
            modelBuilder.Entity<DetalleCita>()
                .HasOne<Cita>()
                .WithMany()
                .HasForeignKey(d => d.CitaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Servicio 1 -- N DetallesCita
            modelBuilder.Entity<DetalleCita>()
                .HasOne<Servicio>()
                .WithMany()
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita 1 -- N Pagos
            modelBuilder.Entity<Pago>()
                .HasOne<Cita>()
                .WithMany()
                .HasForeignKey(p => p.CitaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Usuario 1 -- N Notificaciones
            modelBuilder.Entity<Notificacion>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(n => n.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
