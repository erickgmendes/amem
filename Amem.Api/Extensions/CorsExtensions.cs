namespace Amem.Api.Extensions
{
    public static class CorsExtensions
    {
        public static void CorsConfig(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5112") // Modificar
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });
        }
    }
}