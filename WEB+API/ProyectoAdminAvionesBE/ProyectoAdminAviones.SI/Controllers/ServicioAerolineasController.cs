using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioAerolineasController : ControllerBase
    {
        private readonly IAdministradorAerolineas _admin;

        public ServicioAerolineasController(IAdministradorAerolineas admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Aerolinea>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Aerolinea>> ObtenerPorId(int id)
        {
            var aerolinea = await _admin.ObtenerPorIdAsync(id);
            if (aerolinea == null)
                return NotFound();
            return Ok(aerolinea);
        }

        [HttpGet("ObtenerPorNombre")]
        public async Task<ActionResult<Aerolinea>> ObtenerPorNombre(string nombre)
        {
            var aerolinea = await _admin.ObtenerPorNombreAsync(nombre);
            if (aerolinea == null)
                return NotFound();
            return Ok(aerolinea);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Aerolinea aerolinea)
        {
            await _admin.AgregarAsync(aerolinea);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Aerolinea aerolinea)
        {
            await _admin.EditarAsync(aerolinea);
            return Ok();
        }
    }
}