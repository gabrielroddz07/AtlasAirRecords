using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Contrato de negocio para propietarios: consulta individual y listado,
    /// alta y actualización de datos personales de contacto.
    /// </summary>
    public interface IAdministradorPropietarios
    {
        /// <summary>Obtiene un propietario por id, o null si no existe.</summary>
        Task<Propietario?> ObtenerPorIdAsync(int id);

        /// <summary>Lista todos los propietarios.</summary>
        Task<IEnumerable<Propietario>> ObtenerAsync();

        /// <summary>Registra un propietario nuevo.</summary>
        Task AgregarAsync(Propietario propietario);

        /// <summary>Actualiza los datos de un propietario existente.</summary>
        Task EditarAsync(Propietario propietario);
    }
}
