namespace BlazorMultiApp.Identity.Service.DTOs.Common
{
    public class AuthorizationDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
