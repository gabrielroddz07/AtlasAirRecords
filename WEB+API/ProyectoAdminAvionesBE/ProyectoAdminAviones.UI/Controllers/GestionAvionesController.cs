using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    public class GestionAvionesController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionAvionesController
        public async Task<ActionResult> Index(string busqueda)
        {
            List<Avion> listaDeAviones = await servicioApis.ObtenerAvionesAsync();

            if (!string.IsNullOrEmpty(busqueda))
            {
                listaDeAviones = listaDeAviones
                    .Where(a =>
                        a.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        a.Modelo.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        a.Matricula.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(listaDeAviones);
        }

        // GET: GestionAvionesController/Detalles/0
        public async Task<ActionResult> Detalles(int id)
        {
            Avion avion = await servicioApis.ObtenerAvionPorIdAsync(id);
            return View(avion);
        }

        // GET: GestionAvionesController/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionAvionesController/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Avion avion)
        {
            try
            {
                await servicioApis.AgregarAvionAsync(avion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestionAvionesController/Editar/0
        public async Task<ActionResult> Editar(int id)
        {
            Avion avion = await servicioApis.ObtenerAvionPorIdAsync(id);
            return View(avion);
        }

        // POST: GestionAvionesController/Editar/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Avion avion)
        {
            try
            {
                await servicioApis.EditarAvionAsync(avion);
                return RedirectToAction(nameof(Detalles), new { id = avion.IdAvion });
            }
            catch
            {
                return View(avion);
            }
        }

        // POST: GestionAvionesController/Activar/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Activar(int IdAvion)
        {
            try
            {
                await servicioApis.ActivarAvionAsync(IdAvion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: GestionAvionesController/Desactivar/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Desactivar(int IdAvion)
        {
            try
            {
                await servicioApis.DesactivarAvionAsync(IdAvion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}