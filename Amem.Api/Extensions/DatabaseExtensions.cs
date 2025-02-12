using Microsoft.EntityFrameworkCore;
using Amem.Domain.Data;

namespace Amem.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static void PostgresDatabaseConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
            );
        }
    }
}