using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IAerolineaRepository
    {
        Task<Aerolinea?> ObtenerPorIdAsync(int id);
        Task<Aerolinea?> ObtenerPorNombreAsync(string nombre);
        Task<IEnumerable<Aerolinea>> ObtenerAsync();
        Task AgregarAsync(Aerolinea aerolinea);
        Task ActualizarAsync(Aerolinea aerolinea);
    }
}