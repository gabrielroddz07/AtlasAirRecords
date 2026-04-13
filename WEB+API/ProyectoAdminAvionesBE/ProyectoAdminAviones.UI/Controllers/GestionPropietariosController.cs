using Microsoft.AspNetCore.Mvc;
using ProyectoAdminAviones.Model;

namespace ProyectoAdminAviones.UI.Controllers
{
    /// <summary>
    /// Gestiona las operaciones relacionadas con propietarios en la interfaz de usuario,
    /// permite consultar, buscar, visualizar detalles, crear, editar y listar aviones asociados.
    /// </summary>
    public class GestionPropietariosController(ServicioApi servicioApis) : Controller
    {
        // GET: GestionPropietariosController/0

        /// <summary>
        /// Obtiene la lista de propietarios y permite filtrarlos por criterios de búsqueda
        /// como nombre o identificación.
        /// </summary>
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

        /// <summary>Obtiene los detalles de un propietario específico por id.</summary>
        public async Task<ActionResult> Detalles(int id)
        {
            Propietario propietario = await servicioApis.ObtenerPropietarioPorIdAsync(id);
            return View(propietario);
        }

        // GET: GestionPropietariosController/Crear/0

        /// <summary>Retorna la vista para crear un nuevo propietario.</summary>
        public ActionResult Crear()
        {
            return View();
        }

        // POST: GestionPropietariosController/Crear/0

        /// <summary>Agrega un nuevo propietario y redirige al listado principal.</summary>
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

        /// <summary>Obtiene un propietario por id para su edición.</summary>
        public async Task<ActionResult> Editar(int id)
        {
            Propietario propietario = await servicioApis.ObtenerPropietarioPorIdAsync(id);
            return View(propietario);
        }

        // POST: GestionPropietariosController/Editar/0

        /// <summary>Actualiza un propietario existente y redirige a la vista de detalles.</summary>
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

        /// <summary>
        /// Obtiene la lista de aviones asociados a un propietario específico
        /// y envía información adicional a la vista mediante ViewBag.
        /// </summary>
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