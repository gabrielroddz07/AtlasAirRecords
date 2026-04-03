using ProyectoAdminAviones.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("AdminAvionesApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7044/");
    client.DefaultRequestHeaders.Add("X-API-KEY", "123456");
});

builder.Services.AddScoped<ServicioApi>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/HomePage/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AtlasAirRecords}/{action=HomePage}/{id?}");

app.Run();