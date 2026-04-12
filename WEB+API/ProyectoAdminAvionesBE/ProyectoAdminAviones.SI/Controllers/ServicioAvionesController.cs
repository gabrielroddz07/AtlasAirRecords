using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    /// <summary>
    /// API REST para consultar y gestionar aviones: filtros por aerolínea, propietario y estado,
    /// además de altas, ediciones y activación o baja lógica.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioAvionesController : ControllerBase
    {
        private readonly IAdministradorAviones _admin;

        /// <summary>Inyecta el servicio de negocio de aviones.</summary>
        public ServicioAvionesController(IAdministradorAviones admin)
        {
            _admin = admin;
        }

        /// <summary>Devuelve todos los aviones registrados.</summary>
        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Avion>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        /// <summary>Lista solo aviones en estado activo.</summary>
        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerActivos()
        {
            var lista = await _admin.ObtenerActivosAsync();
            return Ok(lista);
        }

        /// <summary>Lista solo aviones en estado inactivo.</summary>
        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerInactivos()
        {
            var lista = await _admin.ObtenerInactivosAsync();
            return Ok(lista);
        }

        /// <summary>Obtiene un avión por id; 404 si no existe.</summary>
        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Avion>> ObtenerPorId(int id)
        {
            var avion = await _admin.ObtenerPorIdAsync(id);
            if (avion == null)
                return NotFound();
            return Ok(avion);
        }

        /// <summary>Aviones asociados a una aerolínea por su identificador.</summary>
        [HttpGet("ObtenerPorAerolinea")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorAerolinea(int idAerolinea)
        {
            var lista = await _admin.ObtenerPorAerolineaAsync(idAerolinea);
            return Ok(lista);
        }

        /// <summary>Aviones cuya aerolínea tiene el nombre indicado.</summary>
        [HttpGet("ObtenerPorNombreAerolinea")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorNombreAerolinea(string nombre)
        {
            var lista = await _admin.ObtenerPorNombreAerolineaAsync(nombre);
            return Ok(lista);
        }

        /// <summary>Aviones de un propietario identificado por id.</summary>
        [HttpGet("ObtenerPorPropietario")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorPropietario(int idPropietario)
        {
            var lista = await _admin.ObtenerPorPropietarioAsync(idPropietario);
            return Ok(lista);
        }

        /// <summary>Aviones cuyo propietario tiene el nombre indicado.</summary>
        [HttpGet("ObtenerPorNombrePropietario")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorNombrePropietario(string nombre)
        {
            var lista = await _admin.ObtenerPorNombrePropietarioAsync(nombre);
            return Ok(lista);
        }

        /// <summary>Da de alta un avión (el negocio fija estado activo).</summary>
        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Avion avion)
        {
            await _admin.AgregarAsync(avion);
            return Ok();
        }

        /// <summary>Actualiza datos del avión (sin cambiar estado por esta vía).</summary>
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Avion avion)
        {
            await _admin.EditarAsync(avion);
            return Ok();
        }

        /// <summary>Activa un avión por id.</summary>
        [HttpPut("Activar")]
        public async Task<IActionResult> Activar(int id)
        {
            await _admin.ActivarAsync(id);
            return Ok();
        }

        /// <summary>Desactiva un avión por id.</summary>
        [HttpPut("DesActivar")]
        public async Task<IActionResult> DesActivar(int id)
        {
            await _admin.DesActivarAsync(id);
            return Ok();
        }
    }
}
