using BlazorMultiApp.Identity.API.Options;
using BlazorMultiApp.Identity.Infrastructure;
using BlazorMultiApp.Identity.Service;

namespace BlazorMultiApp.API.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .ProcessJWTOptions(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowedOrigins",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowedOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
