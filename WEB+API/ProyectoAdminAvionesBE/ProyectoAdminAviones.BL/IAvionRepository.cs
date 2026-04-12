using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// DA para aviones: consultas con filtros por aerolínea, propietario
    /// y estado, más persistencia y actualización del estado activo/inactivo.
    /// </summary>
    public interface IAvionRepository
    {
        /// <summary>Obtiene un avión por id, incluyendo aerolínea y propietario cuando aplica.</summary>
        Task<Avion?> ObtenerPorIdAsync(int id);

        /// <summary>Lista todos los aviones con relaciones necesarias para la API.</summary>
        Task<IEnumerable<Avion>> ObtenerAsync();

        /// <summary>Filtra por identificador de aerolínea.</summary>
        Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea);

        /// <summary>Filtra por nombre de aerolínea (sin distinguir mayúsculas).</summary>
        Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre);

        /// <summary>Filtra por identificador de propietario.</summary>
        Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario);

        /// <summary>Filtra por nombre de propietario (sin distinguir mayúsculas).</summary>
        Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre);

        /// <summary>Aviones con estado activo.</summary>
        Task<IEnumerable<Avion>> ObtenerActivosAsync();

        /// <summary>Aviones con estado inactivo.</summary>
        Task<IEnumerable<Avion>> ObtenerInactivosAsync();

        /// <summary>Inserta un avión y confirma cambios en base de datos.</summary>
        Task AgregarAsync(Avion avion);

        /// <summary>Persiste modificaciones sobre una entidad ya rastreada o adjunta.</summary>
        Task ActualizarAsync(Avion avion);

        /// <summary>Pone el estado del avión en activo.</summary>
        Task ActivarAsync(int id);

        /// <summary>Pone el estado del avión en inactivo.</summary>
        Task DesActivarAsync(int id);
    }
}
