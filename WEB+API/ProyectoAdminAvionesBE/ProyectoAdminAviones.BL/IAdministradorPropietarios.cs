using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IAdministradorPropietarios
    {
        Task<Propietario?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Propietario>> ObtenerAsync();
        Task AgregarAsync(Propietario propietario);
        Task EditarAsync(Propietario propietario);
    }
}