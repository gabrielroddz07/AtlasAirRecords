using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Contrato de negocio para aerolíneas: consultas por id y nombre, listado general
    /// y mantenimiento básico (alta y edición).
    /// </summary>
    public interface IAdministradorAerolineas
    {
        /// <summary>Obtiene una aerolínea por id, o null si no existe.</summary>
        Task<Aerolinea?> ObtenerPorIdAsync(int id);

        /// <summary>Busca una aerolínea por nombre exacto (sin distinguir mayúsculas).</summary>
        Task<Aerolinea?> ObtenerPorNombreAsync(string nombre);

        /// <summary>Lista todas las aerolíneas.</summary>
        Task<IEnumerable<Aerolinea>> ObtenerAsync();

        /// <summary>Registra una aerolínea nueva.</summary>
        Task AgregarAsync(Aerolinea aerolinea);

        /// <summary>Actualiza los datos de una aerolínea existente.</summary>
        Task EditarAsync(Aerolinea aerolinea);
    }
}
