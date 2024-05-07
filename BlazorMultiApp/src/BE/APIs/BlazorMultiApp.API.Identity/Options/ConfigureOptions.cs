using BlazorMultiApp.Identity.Service.Options.Models;

namespace BlazorMultiApp.Identity.API.Options
{
    public static class ConfigureOptions
    {
        public static IServiceCollection ProcessJWTOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KeyOptions>(configuration.GetSection("JWT"));

            return services;
        }
    }
}
