namespace BlazorMultiApp.Identity.Service.DTOs.Request
{
    public record CreateUserRequestDto(string Email, string FirstName, string LastName, string MiddleName, string Password);
}
