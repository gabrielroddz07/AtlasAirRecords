using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IAvionRepository
    {
        Task<Avion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Avion>> ObtenerAsync();
        Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea);
        Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre);
        Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario);
        Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre);
        Task<IEnumerable<Avion>> ObtenerActivosAsync();
        Task<IEnumerable<Avion>> ObtenerInactivosAsync();
        Task AgregarAsync(Avion avion);
        Task ActualizarAsync(Avion avion);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}