using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Options.Models;
using BlazorMultiApp.Identity.Service.Services.Interfaces;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace BlazorMultiApp.Identity.Service.Services
{
    public class JWTService(IOptions<KeyOptions> KeyOptions) : IJwtService
    {
        public string GenerateAccessToken(User user)
        {
            return GenerateToken(new Dictionary<string, object>
            {
                { ClaimName.ExpirationTime.ToString(), DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds() },
                { ClaimName.FamilyName.ToString(),  user.LastName},
                { ClaimName.GivenName.ToString(), user.LastName},
                { ClaimName.MiddleName.ToString(), user.MiddleName ?? string.Empty},
                { "client_id", user.Id.ToString() }
            });
        }

        public string GenerateRefreshToken()
        {
            return GenerateToken(new Dictionary<string, object>
            {
                { ClaimName.ExpirationTime.ToString(), DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds() },
                { "refresh_token", Guid.NewGuid() } 
            });
        }

        public bool ValidateToken()
        {
            throw new NotImplementedException();
        }
        
        private string GenerateToken(IEnumerable<KeyValuePair<string, object>> claims)
        {
            var rsaKeys = CreateRSAKeys();

            return JwtBuilder.Create()
                .WithAlgorithm(new RS256Algorithm(rsaKeys.privateKey, rsaKeys.publicKey))
                .AddClaims(claims)
                .Encode();
        }

        private (RSA privateKey, RSA publicKey) CreateRSAKeys()
        {
            var rsaPrivate = RSA.Create();
            var rsaPublic = RSA.Create();
            var s = Convert.FromBase64String(KeyOptions.Value.PrivateKey);

            rsaPrivate.ImportRSAPrivateKey(new ReadOnlySpan<byte>(s), out _);
            rsaPrivate.ImportRSAPublicKey(Convert.FromBase64String(KeyOptions.Value.PublicKey), out _);

            return (rsaPrivate, rsaPublic);
        }
    }
}
