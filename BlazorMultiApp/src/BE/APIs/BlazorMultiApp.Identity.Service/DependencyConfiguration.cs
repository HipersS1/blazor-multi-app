using BlazorMultiApp.Identity.Service.Services;
using BlazorMultiApp.Identity.Service.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMultiApp.Identity.Service
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyConfiguration).Assembly;

            services.AddTransient<IJwtService, JWTService>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
