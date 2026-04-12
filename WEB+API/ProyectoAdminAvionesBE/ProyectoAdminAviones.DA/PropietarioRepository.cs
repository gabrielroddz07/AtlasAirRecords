using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    /// <summary>
    /// Persistencia de propietarios: las lecturas cargan aviones y la aerolínea de cada avión
    /// para exponer el contexto completo del titular.
    /// </summary>
    public class PropietarioRepository : IPropietarioRepository
    {
        private readonly AdminAvionesContext _context;

        /// <summary>Crea el repositorio con el contexto de base de datos inyectado.</summary>
        public PropietarioRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        /// <summary>Obtiene un propietario por id con sus aviones y datos de propietario.</summary>
        public async Task<Propietario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Propietarios
                .Include(p => p.Aviones)
                .ThenInclude(a => a.Aerolinea)
                .FirstOrDefaultAsync(p => p.IdPropietario == id);
        }

        /// <summary>Obtiene todos los propietarios con sus aviones y datos de propietario.</summary>
        public async Task<IEnumerable<Propietario>> ObtenerAsync()
        {
            return await _context.Propietarios
                .Include(p => p.Aviones)
                .ThenInclude(a => a.Aerolinea)
                .ToListAsync();
        }

        /// <summary>Agrega un nuevo propietario.</summary>
        public async Task AgregarAsync(Propietario propietario)
        {
            await _context.Propietarios.AddAsync(propietario);
            await _context.SaveChangesAsync();
        }

        /// <summary>Actualiza un propietario existente.</summary>
        public async Task ActualizarAsync(Propietario propietario)
        {
            _context.Propietarios.Update(propietario);
            await _context.SaveChangesAsync();
        }
    }
}
