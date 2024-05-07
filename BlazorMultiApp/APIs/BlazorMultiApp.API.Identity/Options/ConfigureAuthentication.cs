using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlazorMultiApp.Identity.API.Options
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection ConfigureAuthenticationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:PrivateKey"])),
                    ClockSkew = TimeSpan.Zero,
                    ValidAlgorithms = new List<string> { SecurityAlgorithms.HmacSha256 }
                };
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Events.OnRedirectToLogin = c =>
            //    {
            //        c.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        return Task.FromResult<object>(null);
            //    };

            //    //    options.LoginPath = "/api/auth/sign-in-return";
            //    //    options.AccessDeniedPath = "/api/auth/sign-in-return";
            //});

            return services;
        }
    }
}