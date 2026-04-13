/*
 * ProyectoAdminAviones.SI capa de servicio de integracion (API web).
 * Expone controladores REST sobre aviones, aerolineas y propietarios.
 */
using ProyectoAdminAviones.SI;
using ProyectoAdminAviones.DA;
using ProyectoAdminAviones.BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registro de controladores y serializacion JSON.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API Administracion de Aviones", Version = "v1" });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Clave de API en el header: X-API-KEY",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Almacenamiento en memoria (util para pruebas).
builder.Services.AddDbContext<AdminAvionesContext>(options =>
    options.UseInMemoryDatabase("AdminAvionesDB"));

// Repositorios y servicios de negocio con alcance por peticion.
builder.Services.AddScoped<IAvionRepository, AvionRepository>();
builder.Services.AddScoped<IAdministradorAviones, AdministradorAviones>();
builder.Services.AddScoped<IAerolineaRepository, AerolineaRepository>();
builder.Services.AddScoped<IAdministradorAerolineas, AdministradorAerolineas>();
builder.Services.AddScoped<IPropietarioRepository, PropietarioRepository>();
builder.Services.AddScoped<IAdministradorPropietarios, AdministradorPropietarios>();

// CORS permisivo para consumo desde frontends durante el desarrollo.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

// Comprueba X-API-KEY antes de llegar a los controladores.
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();
app.Run();
