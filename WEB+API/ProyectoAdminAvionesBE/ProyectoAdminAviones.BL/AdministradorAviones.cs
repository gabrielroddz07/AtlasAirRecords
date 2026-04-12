using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.BL
{
    /// <summary>
    /// Orquesta las operaciones sobre aviones: delega la persistencia al repositorio
    /// y aplica reglas como asignar estado activo al dar de alta o copiar solo campos editables al modificar.
    /// </summary>
    public class AdministradorAviones : IAdministradorAviones
    {
        private readonly IAvionRepository _avionRepository;

        /// <summary>Crea el administrador con el repositorio de aviones inyectado.</summary>
        public AdministradorAviones(IAvionRepository avionRepository)
        {
            _avionRepository = avionRepository;
        }

        /// <summary>Obtiene un avión por id con su aerolinea y propietario.</summary>
        public async Task<Avion?> ObtenerPorIdAsync(int id)
        {
            return await _avionRepository.ObtenerPorIdAsync(id);
        }

        /// <summary>Obtiene todos los aviones con su aerolinea y propietario.</summary>
        public async Task<IEnumerable<Avion>> ObtenerAsync()
        {
            return await _avionRepository.ObtenerAsync();
        }

        /// <summary>Obtiene todos los aviones con una aerolinea especifica.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorAerolineaAsync(int idAerolinea)
        {
            return await _avionRepository.ObtenerPorAerolineaAsync(idAerolinea);
        }

        /// <summary>Obtiene todos los aviones con una aerolinea especifica por nombre.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorNombreAerolineaAsync(string nombre)
        {
            return await _avionRepository.ObtenerPorNombreAerolineaAsync(nombre);
        }

        /// <summary>Obtiene todos los aviones con un propietario especifica por id.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorPropietarioAsync(int idPropietario)
        {
            return await _avionRepository.ObtenerPorPropietarioAsync(idPropietario);
        }

        /// <summary>Obtiene todos los aviones con un propietario especifica por nombre.</summary>
        public async Task<IEnumerable<Avion>> ObtenerPorNombrePropietarioAsync(string nombre)
        {
            return await _avionRepository.ObtenerPorNombrePropietarioAsync(nombre);
        }

        /// <summary>Obtiene todos los aviones con estado activo.</summary>
        public async Task<IEnumerable<Avion>> ObtenerActivosAsync()
        {
            return await _avionRepository.ObtenerActivosAsync();
        }

        /// <summary>Obtiene todos los aviones con estado inactivo.</summary>
        public async Task<IEnumerable<Avion>> ObtenerInactivosAsync()
        {
            return await _avionRepository.ObtenerInactivosAsync();
        }

        /// <summary>Agrega un nuevo avión.</summary>
        public async Task AgregarAsync(Avion avion)
        {
            avion.Estado = Estado.Activo;
            await _avionRepository.AgregarAsync(avion);
        }

        /// <summary>Actualiza un avión existente.</summary>
        public async Task EditarAsync(Avion avion)
        {
            var avionAModificar = await _avionRepository.ObtenerPorIdAsync(avion.IdAvion);
            if (avionAModificar != null)
            {
                avionAModificar.Nombre = avion.Nombre;
                avionAModificar.Modelo = avion.Modelo;
                avionAModificar.Matricula = avion.Matricula;
                avionAModificar.AnnoFabricacion = avion.AnnoFabricacion;
                avionAModificar.IdAerolinea = avion.IdAerolinea;
                avionAModificar.IdPropietario = avion.IdPropietario;

                await _avionRepository.ActualizarAsync(avionAModificar);
            }
        }

        /// <summary>Activa un avión.</summary>
        public async Task ActivarAsync(int id)
        {
            await _avionRepository.ActivarAsync(id);
        }

        /// <summary>Desactiva un avión.</summary>
        public async Task DesActivarAsync(int id)
        {
            await _avionRepository.DesActivarAsync(id);
        }
    }
}
