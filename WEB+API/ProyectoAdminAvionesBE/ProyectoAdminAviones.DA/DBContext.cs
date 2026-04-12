using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    /// <summary>
    /// Contexto de Entity Framework para el dominio de administración de aviones:
    /// expone los conjuntos de aerolíneas, aviones y propietarios y configura las relaciones uno-a-muchos.
    /// </summary>
    public class AdminAvionesContext : DbContext
    {
        /// <summary>Inicializa el contexto con las opciones suministradas por la aplicación (cadena o base en memoria).</summary>
        public AdminAvionesContext(DbContextOptions<AdminAvionesContext> options)
            : base(options)
        {
        }

        /// <summary>Tabla/conjunto de aerolíneas.</summary>
        public DbSet<Aerolinea> Aerolineas { get; set; }

        /// <summary>Tabla/conjunto de aviones.</summary>
        public DbSet<Avion> Aviones { get; set; }

        /// <summary>Tabla/conjunto de propietarios.</summary>
        public DbSet<Propietario> Propietarios { get; set; }

        /// <summary>
        /// Define claves foráneas: cada avión pertenece a una aerolínea y a un propietario;
        /// la aerolínea y el propietario pueden tener muchos aviones.
        /// </summary>
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
