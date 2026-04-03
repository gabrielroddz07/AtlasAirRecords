using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    public class AerolineaRepository : IAerolineaRepository
    {
        private readonly AdminAvionesContext _context;

        public AerolineaRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        public async Task<Aerolinea?> ObtenerPorIdAsync(int id)
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .FirstOrDefaultAsync(a => a.IdAerolinea == id);
        }

        public async Task<Aerolinea?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .FirstOrDefaultAsync(a => a.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<IEnumerable<Aerolinea>> ObtenerAsync()
        {
            return await _context.Aerolineas
                .Include(a => a.Aviones)
                    .ThenInclude(av => av.Propietario)
                .ToListAsync();
        }

        public async Task AgregarAsync(Aerolinea aerolinea)
        {
            await _context.Aerolineas.AddAsync(aerolinea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Aerolinea aerolinea)
        {
            _context.Aerolineas.Update(aerolinea);
            await _context.SaveChangesAsync();
        }
    }
}