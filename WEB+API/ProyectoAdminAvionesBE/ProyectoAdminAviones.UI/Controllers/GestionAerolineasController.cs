using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con aerolíneas en la interfaz de usuario,
    /// permite consultar, buscar, visualizar detalles, crear, editar y listar aviones asociados.
    /// </summary>
    public class GestionAerolineasController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionAerolineasController/0

        /// <summary>
        /// Obtiene la lista de aerolíneas y permite filtrarlas por criterios de búsqueda
        /// como nombre, país o correo electrónico.
        /// </summary>
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

        /// <summary>Obtiene los detalles de una aerolínea específica por id.</summary>
        public async Task<ActionResult> Detalles(int id)
        {
            Aerolinea aerolinea = await servicioApis.ObtenerAerolineaPorIdAsync(id);
            return View(aerolinea);
        }

        // GET: GestionAerolineasController/Crear/0

        /// <summary>Retorna la vista para crear una nueva aerolínea.</summary>
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionAerolineasController/Crear/0

        /// <summary>Agrega una nueva aerolínea y redirige al listado principal.</summary>
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

        /// <summary>Obtiene una aerolínea por id para su edición.</summary>
        public async Task<ActionResult> Editar(int id)
        {
            Aerolinea aerolinea = await servicioApis.ObtenerAerolineaPorIdAsync(id);
            return View(aerolinea);
        }

        // POST: GestionAerolineasController/Editar/0

        /// <summary>Actualiza una aerolínea existente y redirige a la vista de detalles.</summary>
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

        /// <summary>
        /// Obtiene la lista de aviones asociados a una aerolínea específica
        /// y envía información adicional a la vista mediante ViewBag.
        /// </summary>
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