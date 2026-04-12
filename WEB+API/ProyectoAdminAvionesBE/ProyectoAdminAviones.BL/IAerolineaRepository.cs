using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// DA para aerolíneas: lectura con aviones anidados y operaciones de escritura.
    /// </summary>
    public interface IAerolineaRepository
    {
        /// <summary>Obtiene una aerolínea por id con sus aviones y datos de propietario.</summary>
        Task<Aerolinea?> ObtenerPorIdAsync(int id);

        /// <summary>Busca por nombre (sin distinguir mayúsculas), con aviones cargados.</summary>
        Task<Aerolinea?> ObtenerPorNombreAsync(string nombre);

        /// <summary>Lista todas las aerolíneas con relaciones para respuestas enriquecidas.</summary>
        Task<IEnumerable<Aerolinea>> ObtenerAsync();

        /// <summary>Inserta una aerolínea nueva.</summary>
        Task AgregarAsync(Aerolinea aerolinea);

        /// <summary>Actualiza una aerolínea existente.</summary>
        Task ActualizarAsync(Aerolinea aerolinea);
    }
}
