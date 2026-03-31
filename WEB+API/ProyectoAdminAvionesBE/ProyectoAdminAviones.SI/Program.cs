using ProyectoAdminAviones.SI;
using ProyectoAdminAviones.DA;
using ProyectoAdminAviones.BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// Servicios del contenedor
// ==========================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API Administración de Aviones", Version = "v1" });

    // Definición de API Key
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Clave de API en el header: X-API-KEY",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    // Requerimiento de seguridad
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

// ==========================
// Entity Framework InMemory
// ==========================
builder.Services.AddDbContext<AdminAvionesContext>(options =>
    options.UseInMemoryDatabase("AdminAvionesDB"));

// ==========================
// Inyección de dependencias
// ==========================
builder.Services.AddScoped<IAvionRepository, AvionRepository>();
builder.Services.AddScoped<IAdministradorAviones, AdministradorAviones>();
builder.Services.AddScoped<IAerolineaRepository, AerolineaRepository>();
builder.Services.AddScoped<IAdministradorAerolineas, AdministradorAerolineas>();

// ==========================
// CORS
// ==========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ==========================
// Middleware
// ==========================
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

// Middleware de API Key
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();
app.Run();