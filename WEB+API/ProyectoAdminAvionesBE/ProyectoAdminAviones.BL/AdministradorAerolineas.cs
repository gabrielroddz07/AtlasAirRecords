using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Implementación del caso de uso de aerolíneas: lee y escribe a través del repositorio
    /// y, al editar, vuelca los campos sobre la entidad ya persistida para no perder relaciones.
    /// </summary>
    public class AdministradorAerolineas : IAdministradorAerolineas
    {
        private readonly IAerolineaRepository _aerolineaRepository;

        /// <summary>Crea el administrador con el repositorio de aerolíneas inyectado.</summary>
        public AdministradorAerolineas(IAerolineaRepository aerolineaRepository)
        {
            _aerolineaRepository = aerolineaRepository;
        }

        /// <summary>Obtiene una aerolinea por id con sus aviones y datos de propietario.</summary>
        public async Task<Aerolinea?> ObtenerPorIdAsync(int id)
        {
            return await _aerolineaRepository.ObtenerPorIdAsync(id);
        }

        /// <summary>Obtiene una aerolinea por nombre con sus aviones y datos de propietario.</summary>
        public async Task<Aerolinea?> ObtenerPorNombreAsync(string nombre)
        {
            return await _aerolineaRepository.ObtenerPorNombreAsync(nombre);
        }

        /// <summary>Obtiene todas las aerolineas con sus aviones y datos de propietario.</summary>
        public async Task<IEnumerable<Aerolinea>> ObtenerAsync()
        {
            return await _aerolineaRepository.ObtenerAsync();
        }

        /// <summary>Agrega una nueva aerolinea.</summary>
        public async Task AgregarAsync(Aerolinea aerolinea)
        {
            await _aerolineaRepository.AgregarAsync(aerolinea);
        }

        /// <summary>Actualiza una aerolinea existente.</summary>
        public async Task EditarAsync(Aerolinea aerolinea)
        {
            var aerolineaAModificar = await _aerolineaRepository
                .ObtenerPorIdAsync(aerolinea.IdAerolinea);

            if (aerolineaAModificar != null)
            {
                aerolineaAModificar.Nombre = aerolinea.Nombre;
                aerolineaAModificar.Telefono = aerolinea.Telefono;
                aerolineaAModificar.Pais = aerolinea.Pais;
                aerolineaAModificar.Correo = aerolinea.Correo;
                aerolineaAModificar.FechaFundacion = aerolinea.FechaFundacion;

                await _aerolineaRepository.ActualizarAsync(aerolineaAModificar);
            }
        }
    }
}
