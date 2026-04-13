using Newtonsoft.Json;
using ProyectoAdminAviones.Model;
using System.Text;

namespace ProyectoAdminAviones.UI
{
    /// <summary>
    /// Centraliza la comunicación de la capa UI con la API de administración de aviones,
    /// realiza solicitudes HTTP para consultar, agregar, editar y cambiar estado de aviones,
    /// así como gestionar aerolíneas y propietarios.
    /// </summary>
    public class ServicioApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>Crea el servicio con la fábrica de clientes HTTP inyectada.</summary>
        public ServicioApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Aviones

        /// <summary>Obtiene la lista de todos los aviones.</summary>
        public async Task<List<Avion>> ObtenerAvionesAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioAviones/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

        /// <summary>Obtiene un avión por id.</summary>
        public async Task<Avion?> ObtenerAvionPorIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAviones/ObtenerPorId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var avion = JsonConvert.DeserializeObject<Avion>(result);
                return avion;
            }
            return null;
        }

        /// <summary>Obtiene todos los aviones de una aerolínea específica.</summary>
        public async Task<List<Avion>> ObtenerAvionesPorAerolineaAsync(int idAerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAviones/ObtenerPorAerolinea?idAerolinea={idAerolinea}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

        /// <summary>Obtiene todos los aviones de un propietario específico.</summary>
        public async Task<List<Avion>> ObtenerAvionesPorPropietarioAsync(int idPropietario)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAviones/ObtenerPorPropietario?idPropietario={idPropietario}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

        /// <summary>Agrega un nuevo avión por medio de la API.</summary>
        public async Task AgregarAvionAsync(Avion avion)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioAviones/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>Actualiza un avión existente por medio de la API.</summary>
        public async Task EditarAvionAsync(Avion avion)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/ServicioAviones/Editar", content);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>Activa un avión por id.</summary>
        public async Task ActivarAvionAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.PutAsync($"api/ServicioAviones/Activar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>Desactiva un avión por id.</summary>
        public async Task DesactivarAvionAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.PutAsync($"api/ServicioAviones/DesActivar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        // Aerolineas

        /// <summary>Obtiene la lista de todas las aerolíneas.</summary>
        public async Task<List<Aerolinea>> ObtenerAerolineasAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioAerolineas/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Aerolinea>>(result) ?? [];
            return lista;
        }

        /// <summary>Obtiene una aerolínea por id.</summary>
        public async Task<Aerolinea?> ObtenerAerolineaPorIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAerolineas/ObtenerPorId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var aerolinea = JsonConvert.DeserializeObject<Aerolinea>(result);
                return aerolinea;
            }
            return null;
        }

        /// <summary>Obtiene una aerolínea por nombre.</summary>
        public async Task<Aerolinea?> ObtenerAerolineaPorNombreAsync(string nombre)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAerolineas/ObtenerPorNombre?nombre={nombre}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var aerolinea = JsonConvert.DeserializeObject<Aerolinea>(result);
                return aerolinea;
            }
            return null;
        }

        /// <summary>Agrega una nueva aerolínea por medio de la API.</summary>
        public async Task AgregarAerolineaAsync(Aerolinea aerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(aerolinea);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioAerolineas/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>Actualiza una aerolínea existente por medio de la API.</summary>
        public async Task EditarAerolineaAsync(Aerolinea aerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(aerolinea);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/ServicioAerolineas/Editar", content);
            response.EnsureSuccessStatusCode();
        }

        // Propietarios

        /// <summary>Obtiene la lista de todos los propietarios.</summary>
        public async Task<List<Propietario>> ObtenerPropietariosAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioPropietarios/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Propietario>>(result) ?? [];
            return lista;
        }

        /// <summary>Obtiene un propietario por id.</summary>
        public async Task<Propietario?> ObtenerPropietarioPorIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioPropietarios/ObtenerPorId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var propietario = JsonConvert.DeserializeObject<Propietario>(result);
                return propietario;
            }
            return null;
        }

        /// <summary>Agrega un nuevo propietario por medio de la API.</summary>
        public async Task AgregarPropietarioAsync(Propietario propietario)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(propietario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioPropietarios/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>Actualiza un propietario existente por medio de la API.</summary>
        public async Task EditarPropietarioAsync(Propietario propietario)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(propietario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/ServicioPropietarios/Editar", content);
            response.EnsureSuccessStatusCode();
        }
    }
}