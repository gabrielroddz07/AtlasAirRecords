using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IAdministradorAerolineas
    {
        Task<Aerolinea?> ObtenerPorIdAsync(int id);
        Task<Aerolinea?> ObtenerPorNombreAsync(string nombre);
        Task<IEnumerable<Aerolinea>> ObtenerAsync();
        Task AgregarAsync(Aerolinea aerolinea);
        Task EditarAsync(Aerolinea aerolinea);
    }
}