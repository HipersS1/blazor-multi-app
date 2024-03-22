using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Options.Models;
using BlazorMultiApp.Identity.Service.Services.Interfaces;
using IdentityModel;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace BlazorMultiApp.Identity.Service.Services
{
    public class JWTService(IOptions<KeyOptions> KeyOptions) : IJwtService
    {
        public string GenerateAccessToken(User user)
        {
            return GenerateToken(new Dictionary<string, object>
            {
                { JwtClaimTypes.Expiration, DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds() },
                { JwtClaimTypes.FamilyName,  user.LastName},
                { JwtClaimTypes.GivenName, user.FirstName},
                { JwtClaimTypes.MiddleName, user.MiddleName ?? string.Empty},
                { JwtClaimTypes.Subject, user.Id.ToString() }
            });
        }

        public string GenerateRefreshToken()
        {
            return GenerateToken(new Dictionary<string, object>
            {
                { JwtClaimTypes.Expiration, DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds() },
                { "refresh_token", Guid.NewGuid() } 
            });
        }

        public bool ValidateToken()
        {
            throw new NotImplementedException();
        }
        
        private string GenerateToken(IEnumerable<KeyValuePair<string, object>> claims)
        {
            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(KeyOptions.Value.PrivateKey)
                .AddClaims(claims)
                .MustVerifySignature()
                .Encode();
        }
    }
}
