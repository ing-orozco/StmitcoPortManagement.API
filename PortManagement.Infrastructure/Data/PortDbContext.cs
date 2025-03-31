using Microsoft.EntityFrameworkCore;
using PortManagement.Domain.Entities;

namespace PortManagement.Infrastructure.Data
{
    public class PortDbContext : DbContext
    {
        public PortDbContext(DbContextOptions<PortDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Buques> Buques { get; set; }
        public DbSet<Cargas> Cargas { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasMany(u => u.Operaciones)
                .WithOne(o => o.Usuario)
                .HasForeignKey(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Buques>()
                .HasMany(b => b.Cargas)
                .WithOne(c => c.Buque)
                .HasForeignKey(c => c.BuqueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Buques>()
            .HasMany(b => b.Operaciones)
            .WithOne(o => o.Buque)
            .HasForeignKey(o => o.BuqueId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cargas>()
                .HasMany(c => c.Operaciones)
                .WithOne(o => o.Carga)
                .HasForeignKey(o => o.CargaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
