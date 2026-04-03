using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioPropietariosController : ControllerBase
    {
        private readonly IAdministradorPropietarios _admin;

        public ServicioPropietariosController(IAdministradorPropietarios admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Propietario>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Propietario>> ObtenerPorId(int id)
        {
            var propietario = await _admin.ObtenerPorIdAsync(id);
            if (propietario == null)
                return NotFound();
            return Ok(propietario);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Propietario propietario)
        {
            await _admin.AgregarAsync(propietario);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Propietario propietario)
        {
            await _admin.EditarAsync(propietario);
            return Ok();
        }
    }
}