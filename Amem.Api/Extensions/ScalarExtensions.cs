using AspNetCore.Scalar;
using Scalar.AspNetCore;

namespace Amem.Api.Extensions
{
    public static class ScalarExtensions
    {

        public static void ScalarConfig(this IServiceCollection service, WebApplication app)
        {
            app.MapScalarApiReference();
            app.UseScalar(options =>
            {
                options.UseTheme(Theme.Default);
                options.RoutePrefix = "api-docs";
            });
        }

    }
}