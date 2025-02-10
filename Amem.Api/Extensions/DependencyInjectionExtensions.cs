// using CliniQCare.Application.Services;
// using CliniQCare.Application.Services.Impl;
// using CliniQCare.Domain.Repositories;
// using CliniQCare.Domain.Repositories.Impl;

using Amem.Application.Services;
using Amem.Domain.Data;
using Amem.Domain.Repositories;

namespace Amem.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {

        public static void DependencyInjection(this IServiceCollection service, WebApplicationBuilder builder)
        {
            LoadAbstractions(builder);
            LoadServices(builder);
            LoadRepositories(builder);
            LoadMappers(builder);
        }

        private static void LoadServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILiturgiaDiariaService, LiturgiaDiariaService>();
        }

        private static void LoadRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILiturgiaDiariaRepository, LiturgiaDiariaRepository>();
        }

        private static void LoadMappers(WebApplicationBuilder builder)
        {
            // builder.Services.AddTransient<IUserMapper, UserMapper>();
        }

        private static void LoadAbstractions(WebApplicationBuilder builder)
        {
            // builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            // builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}