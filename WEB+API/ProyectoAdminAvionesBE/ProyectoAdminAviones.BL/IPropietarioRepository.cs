using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public interface IPropietarioRepository
    {
        Task<Propietario?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Propietario>> ObtenerAsync();
        Task AgregarAsync(Propietario propietario);
        Task ActualizarAsync(Propietario propietario);
    }
}