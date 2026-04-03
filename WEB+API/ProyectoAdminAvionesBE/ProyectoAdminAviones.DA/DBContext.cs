using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    public class AdminAvionesContext : DbContext
    {
        public AdminAvionesContext(DbContextOptions<AdminAvionesContext> options)
            : base(options)
        {
        }

        public DbSet<Aerolinea> Aerolineas { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avion>()
                .HasOne(a => a.Aerolinea)
                .WithMany(ae => ae.Aviones)
                .HasForeignKey(a => a.IdAerolinea);

            modelBuilder.Entity<Avion>()
                .HasOne(a => a.Propietario)
                .WithMany(p => p.Aviones)
                .HasForeignKey(a => a.IdPropietario);
        }
    }
}