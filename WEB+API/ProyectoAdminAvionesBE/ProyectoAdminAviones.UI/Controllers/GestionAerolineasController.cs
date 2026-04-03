using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    public class GestionAerolineasController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionAerolineasController/0
        public async Task<ActionResult> Index(string busqueda)
        {
            List<Aerolinea> listaDeAerolineas = await servicioApis.ObtenerAerolineasAsync();

            if (!string.IsNullOrEmpty(busqueda))
            {
                listaDeAerolineas = listaDeAerolineas
                    .Where(a =>
                        a.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        a.Pais.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        a.Correo.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(listaDeAerolineas);
        }

        // GET: GestionAerolineasController/Detalles/0
        public async Task<ActionResult> Detalles(int id)
        {
            Aerolinea aerolinea = await servicioApis.ObtenerAerolineaPorIdAsync(id);
            return View(aerolinea);
        }

        // GET: GestionAerolineasController/Crear/0
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionAerolineasController/Crear/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Aerolinea aerolinea)
        {
            try
            {
                await servicioApis.AgregarAerolineaAsync(aerolinea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(aerolinea);
            }
        }

        // GET: GestionAerolineasController/Editar/0
        public async Task<ActionResult> Editar(int id)
        {
            Aerolinea aerolinea = await servicioApis.ObtenerAerolineaPorIdAsync(id);
            return View(aerolinea);
        }

        // POST: GestionAerolineasController/Editar/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Aerolinea aerolinea)
        {
            try
            {
                await servicioApis.EditarAerolineaAsync(aerolinea);
                return RedirectToAction(nameof(Detalles), new { id = aerolinea.IdAerolinea });
            }
            catch
            {
                return View(aerolinea);
            }
        }

        // GET: GestionAerolineasController/VerAviones/0
        public async Task<ActionResult> VerAviones(int id)
        {
            Aerolinea aerolinea = await servicioApis.ObtenerAerolineaPorIdAsync(id);
            List<Avion> listaDeAviones = await servicioApis.ObtenerAvionesPorAerolineaAsync(id);

            ViewBag.IdAerolinea = aerolinea.IdAerolinea;
            ViewBag.NombreAerolinea = aerolinea.Nombre;

            return View(listaDeAviones);
        }
    }
}