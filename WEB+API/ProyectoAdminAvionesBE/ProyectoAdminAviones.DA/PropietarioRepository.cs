using Microsoft.EntityFrameworkCore;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.DA
{
    public class PropietarioRepository : IPropietarioRepository
    {
        private readonly AdminAvionesContext _context;

        public PropietarioRepository(AdminAvionesContext context)
        {
            _context = context;
        }

        public async Task<Propietario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Propietarios
                .Include(p => p.Aviones)
                .ThenInclude(a => a.Aerolinea)
                .FirstOrDefaultAsync(p => p.IdPropietario == id);
        }

        public async Task<IEnumerable<Propietario>> ObtenerAsync()
        {
            return await _context.Propietarios
                .Include(p => p.Aviones)
                .ThenInclude(a => a.Aerolinea)
                .ToListAsync();
        }

        public async Task AgregarAsync(Propietario propietario)
        {
            await _context.Propietarios.AddAsync(propietario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Propietario propietario)
        {
            _context.Propietarios.Update(propietario);
            await _context.SaveChangesAsync();
        }
    }
}