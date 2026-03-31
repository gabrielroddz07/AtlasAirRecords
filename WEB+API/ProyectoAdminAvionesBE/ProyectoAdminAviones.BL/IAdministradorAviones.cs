using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IAdministradorAviones
    {
        Task<Avion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Avion>> ObtenerAsync();
        Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea);
        Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre);
        Task<IEnumerable<Avion>> ObtenerActivosAsync();
        Task<IEnumerable<Avion>> ObtenerInactivosAsync();
        Task AgregarAsync(Avion avion);
        Task EditarAsync(Avion avion);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}