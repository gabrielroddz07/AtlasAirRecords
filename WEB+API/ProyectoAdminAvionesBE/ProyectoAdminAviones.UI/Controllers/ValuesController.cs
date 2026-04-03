using Microsoft.AspNetCore.Mvc;

namespace ProyectoAdminAviones.UI.Controllers
{
    public class AtlasAirRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}