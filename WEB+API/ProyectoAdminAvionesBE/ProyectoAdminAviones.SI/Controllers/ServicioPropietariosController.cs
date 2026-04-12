using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    /// <summary>
    /// API REST para propietarios: listado, consulta por id y mantenimiento (alta y edición).
    /// Los listados pueden traer aviones y aerolínea asociada gracias a las inclusiones en el repositorio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioPropietariosController : ControllerBase
    {
        private readonly IAdministradorPropietarios _admin;

        /// <summary>Inyecta el servicio de negocio de propietarios.</summary>
        public ServicioPropietariosController(IAdministradorPropietarios admin)
        {
            _admin = admin;
        }

        /// <summary>Lista todos los propietarios.</summary>
        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Propietario>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        /// <summary>Obtiene un propietario por id; 404 si no existe.</summary>
        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Propietario>> ObtenerPorId(int id)
        {
            var propietario = await _admin.ObtenerPorIdAsync(id);
            if (propietario == null)
                return NotFound();
            return Ok(propietario);
        }

        /// <summary>Registra un propietario nuevo.</summary>
        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Propietario propietario)
        {
            await _admin.AgregarAsync(propietario);
            return Ok();
        }

        /// <summary>Actualiza los datos de un propietario existente.</summary>
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Propietario propietario)
        {
            await _admin.EditarAsync(propietario);
            return Ok();
        }
    }
}
