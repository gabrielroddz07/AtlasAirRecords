using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    public class GestionPropietariosController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionPropietariosController/0
        public async Task<ActionResult> Index(string busqueda)
        {
            List<Propietario> listaDePropietarios = await servicioApis.ObtenerPropietariosAsync();

            if (!string.IsNullOrEmpty(busqueda))
            {
                listaDePropietarios = listaDePropietarios
                    .Where(p =>
                        p.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        p.Identificacion.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(listaDePropietarios);
        }

        // GET: GestionPropietariosController/Detalles/0
        public async Task<ActionResult> Detalles(int id)
        {
            Propietario propietario = await servicioApis.ObtenerPropietarioPorIdAsync(id);
            return View(propietario);
        }

        // GET: GestionPropietariosController/Crear/0
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionPropietariosController/Crear/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Propietario propietario)
        {
            try
            {
                await servicioApis.AgregarPropietarioAsync(propietario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(propietario);
            }
        }

        // GET: GestionPropietariosController/Editar/0
        public async Task<ActionResult> Editar(int id)
        {
            Propietario propietario = await servicioApis.ObtenerPropietarioPorIdAsync(id);
            return View(propietario);
        }

        // POST: GestionPropietariosController/Editar/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Propietario propietario)
        {
            try
            {
                await servicioApis.EditarPropietarioAsync(propietario);
                return RedirectToAction(nameof(Detalles), new { id = propietario.IdPropietario });
            }
            catch
            {
                return View(propietario);
            }
        }

        // GET: GestionPropietariosController/VerAviones/0
        public async Task<ActionResult> VerAviones(int id)
        {
            Propietario propietario = await servicioApis.ObtenerPropietarioPorIdAsync(id);
            List<Avion> listaDeAviones = await servicioApis.ObtenerAvionesPorPropietarioAsync(id);

            ViewBag.IdPropietario = propietario.IdPropietario;
            ViewBag.NombrePropietario = propietario.Nombre;

            return View(listaDeAviones);
        }
    }
}