using BlazorMultiApp.Identity.Domain.Models;

namespace BlazorMultiApp.Identity.Service.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        bool ValidateToken();
    }
}
