using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con aviones en la interfaz de usuario,
    /// permite consultar, buscar, visualizar detalles, crear, editar y cambiar el estado de los aviones.
    /// </summary>
    public class GestionAvionesController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionAvionesController

        /// <summary>
        /// Obtiene la lista de aviones y permite filtrarlos por criterios de búsqueda
        /// como nombre, modelo o matrícula.
        /// </summary>
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

        /// <summary>Obtiene los detalles de un avión específico por id.</summary>
        public async Task<ActionResult> Detalles(int id)
        {
            Avion avion = await servicioApis.ObtenerAvionPorIdAsync(id);
            return View(avion);
        }

        // GET: GestionAvionesController/Crear

        /// <summary>Retorna la vista para crear un nuevo avión.</summary>
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionAvionesController/Crear

        /// <summary>Agrega un nuevo avión y redirige al listado principal.</summary>
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

        /// <summary>Obtiene un avión por id para su edición.</summary>
        public async Task<ActionResult> Editar(int id)
        {
            Avion avion = await servicioApis.ObtenerAvionPorIdAsync(id);
            return View(avion);
        }

        // POST: GestionAvionesController/Editar/0

        /// <summary>Actualiza un avión existente y redirige a la vista de detalles.</summary>
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

        /// <summary>Activa un avión por id y redirige al listado principal.</summary>
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

        /// <summary>Desactiva un avión por id y redirige al listado principal.</summary>
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