using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// BL para aviones: consultas por aerolínea, propietario,
    /// estado y operaciones de alta, edición y cambio de estado.
    /// </summary>
    public interface IAdministradorAviones
    {
        /// <summary>Obtiene un avión por su identificador, o null si no existe.</summary>
        Task<Avion?> ObtenerPorIdAsync(int id);

        /// <summary>Lista todos los aviones con sus relaciones cargadas según el repositorio.</summary>
        Task<IEnumerable<Avion>> ObtenerAsync();

        /// <summary>Aviones pertenecientes a una aerolínea concreta (por id).</summary>
        Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea);

        /// <summary>Aviones cuya aerolínea coincide con el nombre indicado (comparación sin distinguir mayúsculas).</summary>
        Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre);

        /// <summary>Aviones asociados a un propietario por su identificador.</summary>
        Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario);

        /// <summary>Aviones cuyo propietario tiene el nombre indicado (comparación sin distinguir mayúsculas).</summary>
        Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre);

        /// <summary>Solo aviones en estado activo.</summary>
        Task<IEnumerable<Avion>> ObtenerActivosAsync();

        /// <summary>Solo aviones en estado inactivo.</summary>
        Task<IEnumerable<Avion>> ObtenerInactivosAsync();

        /// <summary>Registra un avión nuevo; el negocio fija el estado inicial como activo.</summary>
        Task AgregarAsync(Avion avion);

        /// <summary>Actualiza datos editables del avión; no modifica el estado salvo por Activar/DesActivar.</summary>
        Task EditarAsync(Avion avion);

        /// <summary>Marca el avión como activo.</summary>
        Task ActivarAsync(int id);

        /// <summary>Marca el avión como inactivo.</summary>
        Task DesActivarAsync(int id);
    }
}
