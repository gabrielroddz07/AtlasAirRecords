using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    /// <summary>
    /// API REST para aerolíneas: listado, búsqueda por id o nombre y operaciones de alta y edición.
    /// Las respuestas pueden incluir aviones y propietarios según lo resuelva la capa de datos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioAerolineasController : ControllerBase
    {
        private readonly IAdministradorAerolineas _admin;

        /// <summary>Inyecta el servicio de negocio de aerolíneas.</summary>
        public ServicioAerolineasController(IAdministradorAerolineas admin)
        {
            _admin = admin;
        }

        /// <summary>Lista todas las aerolíneas.</summary>
        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Aerolinea>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        /// <summary>Obtiene una aerolínea por id; 404 si no existe.</summary>
        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Aerolinea>> ObtenerPorId(int id)
        {
            var aerolinea = await _admin.ObtenerPorIdAsync(id);
            if (aerolinea == null)
                return NotFound();
            return Ok(aerolinea);
        }

        /// <summary>Busca una aerolínea por nombre exacto (sin distinguir mayúsculas).</summary>
        [HttpGet("ObtenerPorNombre")]
        public async Task<ActionResult<Aerolinea>> ObtenerPorNombre(string nombre)
        {
            var aerolinea = await _admin.ObtenerPorNombreAsync(nombre);
            if (aerolinea == null)
                return NotFound();
            return Ok(aerolinea);
        }

        /// <summary>Registra una aerolínea nueva.</summary>
        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Aerolinea aerolinea)
        {
            await _admin.AgregarAsync(aerolinea);
            return Ok();
        }

        /// <summary>Actualiza los datos de una aerolínea existente.</summary>
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Aerolinea aerolinea)
        {
            await _admin.EditarAsync(aerolinea);
            return Ok();
        }
    }
}
