using Newtonsoft.Json;
using ProyectoAdminAviones.Model;
using System.Text;

namespace ProyectoAdminAviones.UI
{
    public class ServicioApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Aviones

        public async Task<List<Avion>> ObtenerAvionesAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioAviones/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

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

        public async Task<List<Avion>> ObtenerAvionesPorAerolineaAsync(int idAerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAviones/ObtenerPorAerolinea?idAerolinea={idAerolinea}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

        public async Task<List<Avion>> ObtenerAvionesPorPropietarioAsync(int idPropietario)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync($"api/ServicioAviones/ObtenerPorPropietario?idPropietario={idPropietario}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Avion>>(result) ?? [];
            return lista;
        }

        public async Task AgregarAvionAsync(Avion avion)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioAviones/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditarAvionAsync(Avion avion)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(avion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/ServicioAviones/Editar", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActivarAvionAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.PutAsync($"api/ServicioAviones/Activar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task DesactivarAvionAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.PutAsync($"api/ServicioAviones/DesActivar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        // Aerolineas

        public async Task<List<Aerolinea>> ObtenerAerolineasAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioAerolineas/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Aerolinea>>(result) ?? [];
            return lista;
        }

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

        public async Task AgregarAerolineaAsync(Aerolinea aerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(aerolinea);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioAerolineas/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditarAerolineaAsync(Aerolinea aerolinea)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(aerolinea);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/ServicioAerolineas/Editar", content);
            response.EnsureSuccessStatusCode();
        }

        // Propietarios

        public async Task<List<Propietario>> ObtenerPropietariosAsync()
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var response = await client.GetAsync("api/ServicioPropietarios/Obtener");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<Propietario>>(result) ?? [];
            return lista;
        }

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

        public async Task AgregarPropietarioAsync(Propietario propietario)
        {
            var client = _httpClientFactory.CreateClient("AdminAvionesApi");
            var json = JsonConvert.SerializeObject(propietario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/ServicioPropietarios/Agregar", content);
            response.EnsureSuccessStatusCode();
        }

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