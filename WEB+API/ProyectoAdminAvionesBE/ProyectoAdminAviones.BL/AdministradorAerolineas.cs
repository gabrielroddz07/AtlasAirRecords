using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public class AdministradorAerolineas : IAdministradorAerolineas
    {
        private readonly IAerolineaRepository _aerolineaRepository;

        public AdministradorAerolineas(IAerolineaRepository aerolineaRepository)
        {
            _aerolineaRepository = aerolineaRepository;
        }

        public async Task<Aerolinea?> ObtenerPorIdAsync(int id)
        {
            return await _aerolineaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Aerolinea?> ObtenerPorNombreAsync(string nombre)
        {
            return await _aerolineaRepository.ObtenerPorNombreAsync(nombre);
        }

        public async Task<IEnumerable<Aerolinea>> ObtenerAsync()
        {
            return await _aerolineaRepository.ObtenerAsync();
        }

        public async Task AgregarAsync(Aerolinea aerolinea)
        {
            await _aerolineaRepository.AgregarAsync(aerolinea);
        }

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