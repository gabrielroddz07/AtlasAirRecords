using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Contrato de persistencia para propietarios: consultas con aviones y aerolínea asociada.
    /// </summary>
    public interface IPropietarioRepository
    {
        /// <summary>Obtiene un propietario por id con sus aviones y aerolínea de cada avión.</summary>
        Task<Propietario?> ObtenerPorIdAsync(int id);

        /// <summary>Lista propietarios con la misma carga de relaciones.</summary>
        Task<IEnumerable<Propietario>> ObtenerAsync();

        /// <summary>Inserta un propietario nuevo.</summary>
        Task AgregarAsync(Propietario propietario);

        /// <summary>Actualiza un propietario existente.</summary>
        Task ActualizarAsync(Propietario propietario);
    }
}
