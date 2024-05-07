namespace BlazorMultiApp.Identity.Service.DTOs.Request
{
    public record CreateUserRequest(string Email, string FirstName, string LastName, string MiddleName, string Password);
}
