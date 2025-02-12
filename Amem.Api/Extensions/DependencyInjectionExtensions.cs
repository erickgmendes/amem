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

        public static void LoadDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.LoadExternalServices();
            builder.LoadAbstractions();
            builder.LoadServices();
            builder.LoadRepositories();
            builder.LoadMappers();
        }

        private static void LoadExternalServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
        }        
        
        private static void LoadServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IExternalApiService, ExternalApiService>();
            builder.Services.AddTransient<ILiturgiaDiariaService, LiturgiaDiariaService>();
        }

        private static void LoadRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILiturgiaDiariaRepository, LiturgiaDiariaRepository>();
        }

        private static void LoadMappers(this WebApplicationBuilder builder)
        {
            // builder.Services.AddTransient<IUserMapper, UserMapper>();
        }

        private static void LoadAbstractions(this WebApplicationBuilder builder)
        {
            // builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            // builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}