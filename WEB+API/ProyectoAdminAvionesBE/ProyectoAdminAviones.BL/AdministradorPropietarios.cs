using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Implementación del mantenimiento de propietarios: delega en el repositorio
    /// y al editar sincroniza campos sobre la entidad cargada desde persistencia.
    /// </summary>
    public class AdministradorPropietarios : IAdministradorPropietarios
    {
        private readonly IPropietarioRepository _propietarioRepository;

        /// <summary>Crea el administrador con el repositorio de propietarios inyectado.</summary>
        public AdministradorPropietarios(IPropietarioRepository propietarioRepository)
        {
            _propietarioRepository = propietarioRepository;
        }

        /// <summary>Obtiene un propietario por id con sus aviones y datos de propietario.</summary>
        public async Task<Propietario?> ObtenerPorIdAsync(int id)
        {
            return await _propietarioRepository.ObtenerPorIdAsync(id);
        }

        /// <summary>Obtiene todos los propietarios con sus aviones y datos de propietario.</summary>
        public async Task<IEnumerable<Propietario>> ObtenerAsync()
        {
            return await _propietarioRepository.ObtenerAsync();
        }

        /// <summary>Agrega un nuevo propietario.</summary>
        public async Task AgregarAsync(Propietario propietario)
        {
            await _propietarioRepository.AgregarAsync(propietario);
        }

        /// <summary>Actualiza un propietario existente.</summary>
        public async Task EditarAsync(Propietario propietario)
        {
            var propietarioAModificar = await _propietarioRepository
                .ObtenerPorIdAsync(propietario.IdPropietario);

            if (propietarioAModificar != null)
            {
                propietarioAModificar.Nombre = propietario.Nombre;
                propietarioAModificar.Identificacion = propietario.Identificacion;
                propietarioAModificar.Telefono = propietario.Telefono;
                propietarioAModificar.Correo = propietario.Correo;
                propietarioAModificar.FechaNacimiento = propietario.FechaNacimiento;

                await _propietarioRepository.ActualizarAsync(propietarioAModificar);
            }
        }
    }
}
