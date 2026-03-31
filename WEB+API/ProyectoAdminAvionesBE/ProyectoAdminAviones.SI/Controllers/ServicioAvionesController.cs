using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.BL;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioAvionesController : ControllerBase
    {
        private readonly IAdministradorAviones _admin;

        public ServicioAvionesController(IAdministradorAviones admin)
        {
            _admin = admin;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<IEnumerable<Avion>>> Obtener()
        {
            var lista = await _admin.ObtenerAsync();
            return Ok(lista);
        }

        [HttpGet("ObtenerActivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerActivos()
        {
            var lista = await _admin.ObtenerActivosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtenerInactivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerInactivos()
        {
            var lista = await _admin.ObtenerInactivosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtenerPorId")]
        public async Task<ActionResult<Avion>> ObtenerPorId(int id)
        {
            var avion = await _admin.ObtenerPorIdAsync(id);
            if (avion == null)
                return NotFound();
            return Ok(avion);
        }

        [HttpGet("ObtenerPorAerolinea")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorAerolinea(int idAerolinea)
        {
            var lista = await _admin.ObtenerPorAerolineaAsync(idAerolinea);
            return Ok(lista);
        }

        [HttpGet("ObtenerPorNombreAerolinea")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtenerPorNombreAerolinea(string nombre)
        {
            var lista = await _admin.ObtenerPorNombreAerolineaAsync(nombre);
            return Ok(lista);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Avion avion)
        {
            await _admin.AgregarAsync(avion);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] Avion avion)
        {
            await _admin.EditarAsync(avion);
            return Ok();
        }

        [HttpPut("Activar")]
        public async Task<IActionResult> Activar(int id)
        {
            await _admin.ActivarAsync(id);
            return Ok();
        }

        [HttpPut("DesActivar")]
        public async Task<IActionResult> DesActivar(int id)
        {
            await _admin.DesActivarAsync(id);
            return Ok();
        }
    }
}