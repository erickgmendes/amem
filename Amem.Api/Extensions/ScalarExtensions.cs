using AspNetCore.Scalar;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace Amem.Api.Extensions
{
    public static class ScalarExtensions
    {

        public static void ScalarConfig(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.MapScalarApiReference();
            app.UseScalar(options =>
            {
                options.UseTheme(Theme.Default);
                options.RoutePrefix = "api-docs";
            });
        }
        
        public static void SwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
            });
        }

    }
}