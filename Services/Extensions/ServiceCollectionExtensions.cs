using TVShowCatalog.Services.Interfaces;

namespace TVShowCatalog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITvShowService, TvShowService>();
            return services;
        }
    }
}