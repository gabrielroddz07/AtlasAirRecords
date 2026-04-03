using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    public class AvionRepository : IAvionRepository
    {
        private readonly AdminAvionesContext _context;

        public AvionRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        public async Task<Avion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .FirstOrDefaultAsync(a => a.IdAvion == id);
        }

        public async Task<IEnumerable<Avion>> ObtenerAsync()
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea)
        {
            return await _context.Aviones
                .Where(a => a.IdAerolinea == idAerolinea)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .Where(a => a.Aerolinea.Nombre.ToLower() == nombre.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario)
        {
            return await _context.Aviones
                .Where(a => a.IdPropietario == idPropietario)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre)
        {
            return await _context.Aviones
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .Where(a => a.Propietario.Nombre.ToLower() == nombre.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerActivosAsync()
        {
            return await _context.Aviones
                .Where(a => a.Estado == Estado.Activo)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerInactivosAsync()
        {
            return await _context.Aviones
                .Where(a => a.Estado == Estado.Inactivo)
                .Include(a => a.Aerolinea)
                .Include(a => a.Propietario)
                .ToListAsync();
        }

        public async Task AgregarAsync(Avion avion)
        {
            await _context.Aviones.AddAsync(avion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Avion avion)
        {
            _context.Aviones.Update(avion);
            await _context.SaveChangesAsync();
        }

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