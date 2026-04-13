/*
 * ProyectoAdminAviones.UI capa de interfaz de usuario (ASP.NET Core MVC).
 * Configura vistas, servicios HTTP y rutas para consumir la API de administración de aviones.
 */
using ProyectoAdminAviones.UI;

var builder = WebApplication.CreateBuilder(args);

// Registro de controladores con soporte para vistas.
builder.Services.AddControllersWithViews();

// Cliente HTTP para consumir la API principal con direccion base y clave de acceso.
var adminAvionesApiConfig = builder.Configuration.GetSection("AdminAvionesApi");
var urlBase = adminAvionesApiConfig.GetValue<string>("BaseUrl");
var apiKey = adminAvionesApiConfig.GetValue<string>("ApiKey");
builder.Services.AddHttpClient("AdminAvionesApi", client =>
{
    client.BaseAddress = new Uri(urlBase);
    client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
});

// Servicio de apoyo para centralizar las llamadas a la API desde la interfaz.
builder.Services.AddScoped<ServicioApi>();

var app = builder.Build();

// Configuracion de manejo de errores y HSTS para ambientes que no son de desarrollo.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/HomePage/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto hacia el controlador principal y la pagina de inicio del sistema.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AtlasAirRecords}/{action=HomePage}/{id?}");

app.Run();