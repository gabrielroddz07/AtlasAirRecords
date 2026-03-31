using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    public class AdministradorAviones : IAdministradorAviones
    {
        private readonly IAvionRepository _avionRepository;

        public AdministradorAviones(IAvionRepository avionRepository)
        {
            _avionRepository = avionRepository;
        }

        public async Task<Avion?> ObtenerPorIdAsync(int id)
        {
            return await _avionRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Avion>> ObtenerAsync()
        {
            return await _avionRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea)
        {
            return await _avionRepository.ObtenerPorAerolineaAsync(idAerolinea);
        }
        public async Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre)
        {
            return await _avionRepository.ObtenerPorNombreAerolineaAsync(nombre);
        }

        public async Task<IEnumerable<Avion>> ObtenerActivosAsync()
        {
            return await _avionRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Avion>> ObtenerInactivosAsync()
        {
            return await _avionRepository.ObtenerInactivosAsync();
        }

        public async Task AgregarAsync(Avion avion)
        {
            // Al agregar, el avión siempre inicia Activo
            avion.Estado = Estado.Activo;
            await _avionRepository.AgregarAsync(avion);
        }

        public async Task EditarAsync(Avion avion)
        {
            var avionAModificar = await _avionRepository.ObtenerPorIdAsync(avion.IdAvion);
            if (avionAModificar != null)
            {
                avionAModificar.Nombre = avion.Nombre;
                avionAModificar.Modelo = avion.Modelo;
                avionAModificar.IdAerolinea = avion.IdAerolinea;
                await _avionRepository.ActualizarAsync(avionAModificar);
            }
        }

        public async Task ActivarAsync(int id)
        {
            await _avionRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _avionRepository.DesActivarAsync(id);
        }
    }
}