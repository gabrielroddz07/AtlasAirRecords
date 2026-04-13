using Microsoft.AspNetCore.Mvc;

namespace ProyectoAdminAviones.UI.Controllers
{
    /// <summary>
    /// Controlador principal de la aplicación
    /// gestiona la navegación hacia la página de inicio del sistema.
    /// </summary>
    public class AtlasAirRecordsController : Controller
    {
        /// <summary>Retorna la vista principal de inicio de la aplicación.</summary>
        public IActionResult HomePage()
        {
            return View();
        }
    }
}