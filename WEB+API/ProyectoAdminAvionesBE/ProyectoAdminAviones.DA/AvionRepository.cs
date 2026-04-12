using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    /// <summary>
    /// Implementacion de <see cref="IAvionRepository"/> con EF Core: las consultas incluyen aerolinea y propietario
    /// para evitar respuestas con referencias vacias en la API.
    /// </summary>
    public class AvionRepository : IAvionRepository
    {
        private readonly AdminAvionesContext _context;

        /// <summary>Crea el repositorio con el contexto de base de datos inyectado.</summary>
        public AvionRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        /// <summary>Obtiene un avión por id con su aerolinea y propietario.</summary>
        public async Task<Avion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .FirstOrDefaultAsync(a => a.IdAvion == id);
        }

        /// <summary>Obtiene todos los aviones con su aerolinea y propietario.</summary>
        public async Task<IEnumerable<Avion>> ObtenerAsync()
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con una aerolinea especifica.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea)
        {
            return await _context.Aviones
                .Where(a => a.IdAerolinea == idAerolinea)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con una aerolinea especifica por nombre.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .Where(a => a.Aerolinea.Nombre.ToLower() == nombre.ToLower())
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con un propietario especifica por id.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario)
        {
            return await _context.Aviones
                .Where(a => a.IdPropietario == idPropietario)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con un propietario especifica por nombre.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .Where(a => a.Propietario.Nombre.ToLower() == nombre.ToLower())
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con estado activo.</summary>
        public async Task<IEnumerable<Avion>> ObtenerActivosAsync()
        {
            return await _context.Aviones
                .Where(a => a.Estado == Estado.Activo)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        /// <summary>Obtiene todos los aviones con estado inactivo.</summary>
        public async Task<IEnumerable<Avion>> ObtenerInactivosAsync()
        {
            return await _context.Aviones
                .Where(a => a.Estado == Estado.Inactivo)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        /// <summary>Agrega un nuevo avión.</summary>
        public async Task AgregarAsync(Avion avion)
        {
            await _context.Aviones.AddAsync(avion);
            await _context.SaveChangesAsync();
        }

        /// <summary>Actualiza un avión existente.</summary>
        public async Task ActualizarAsync(Avion avion)
        {
            _context.Aviones.Update(avion);
            await _context.SaveChangesAsync();
        }

        /// <summary>Activa un avión.</summary>
        public async Task ActivarAsync(int id)
        {
            var avion = await ObtenerPorIdAsync(id);
            if (avion != null)
            {
                avion.Estado = Estado.Activo;
                _context.Aviones.Update(avion);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>Desactiva un avión.</summary>
        public async Task DesActivarAsync(int id)
        {
            var avion = await ObtenerPorIdAsync(id);
            if (avion != null)
            {
                avion.Estado = Estado.Inactivo;
                _context.Aviones.Update(avion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
