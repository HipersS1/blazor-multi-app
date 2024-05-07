namespace BlazorMultiApp.Identity.Service.DTOs.Request
{
    public record AuthenticateRequest(string Email, string Password);
}
