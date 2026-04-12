using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    /// <summary>
    /// Implementacion de <see cref="IAerolineaRepository">: al leer, incluye aviones y el propietario de cada avión
    /// para devolver grafos útiles en una sola consulta.
    /// </summary>
    public class AerolineaRepository : IAerolineaRepository
    {
        private readonly AdminAvionesContext _context;

        /// <summary>Crea el repositorio con el contexto de base de datos inyectado.</summary>
        public AerolineaRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        /// <summary>Obtiene una aerolinea por id con sus aviones y datos de propietario.</summary>
        public async Task<Aerolinea?> ObtenerPorIdAsync(int id)
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .FirstOrDefaultAsync(a => a.IdAerolinea == id);
        }

        /// <summary>Obtiene una aerolinea por nombre con sus aviones y datos de propietario.</summary>
        public async Task<Aerolinea?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .FirstOrDefaultAsync(a => a.Nombre.ToLower() == nombre.ToLower());
        }

        /// <summary>Obtiene todas las aerolineas con sus aviones y datos de propietario.</summary>
        public async Task<IEnumerable<Aerolinea>> ObtenerAsync()
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .ToListAsync();
        }

        /// <summary>Agrega una nueva aerolinea.</summary>
        public async Task AgregarAsync(Aerolinea aerolinea)
        {
            await _context.Aerolineas.AddAsync(aerolinea);
            await _context.SaveChangesAsync();
        }

        /// <summary>Actualiza una aerolinea existente.</summary>
        public async Task ActualizarAsync(Aerolinea aerolinea)
        {
            _context.Aerolineas.Update(aerolinea);
            await _context.SaveChangesAsync();
        }
    }
}
