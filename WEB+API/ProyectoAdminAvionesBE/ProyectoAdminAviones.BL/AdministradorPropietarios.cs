using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public class AdministradorPropietarios : IAdministradorPropietarios
    {
        private readonly IPropietarioRepository _propietarioRepository;

        public AdministradorPropietarios(IPropietarioRepository propietarioRepository)
        {
            _propietarioRepository = propietarioRepository;
        }

        public async Task<Propietario?> ObtenerPorIdAsync(int id)
        {
            return await _propietarioRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Propietario>> ObtenerAsync()
        {
            return await _propietarioRepository.ObtenerAsync();
        }

        public async Task AgregarAsync(Propietario propietario)
        {
            await _propietarioRepository.AgregarAsync(propietario);
        }

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