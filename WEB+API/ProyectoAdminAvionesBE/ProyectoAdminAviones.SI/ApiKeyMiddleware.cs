namespace ProyectoAdminAviones.SI
{
    /// <summary>
    /// Middleware que exige el header en cada peticion y lo compara con una clave valida.
    /// Responde 401 si falta la clave y 403 si no coincide; en caso contrario deja pasar al resto del pipeline.
    /// </summary>
    /// <remarks>La clave esta definida en codigo solo a modo de ejemplo; en produccion conviene configurarla por secretos o variables de entorno.</remarks>
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "X-API-KEY";
        private const string VALID_API_KEY = "123456";

        /// <summary>Registra el siguiente delegado del pipeline HTTP.</summary>
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>Valida la API key y continúa la petición o corta con el código HTTP correspondiente.</summary>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key no proporcionada");
                return;
            }

            if (!VALID_API_KEY.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("API Key inválida");
                return;
            }

            await _next(context);
        }
    }
}
