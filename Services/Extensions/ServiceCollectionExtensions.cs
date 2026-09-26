using TVShowCatalog.Interfaces;
using TVShowCatalog.Models;
using TVShowCatalog.Repositories;

namespace TVShowCatalog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITvShowService, TvShowService>();
            services.AddScoped<IRepository<TvShow>, TvShowRepository>();

            return services;
        }
    }
}