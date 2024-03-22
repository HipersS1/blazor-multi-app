namespace BlazorMultiApp.Constants
{
    public static class Addresses
    {
        private const string BaseControllerPrefix = "api/";
        private const string AuthControllerPrefix = "auth/";

        public const string SignInEndpoint = $"{BaseControllerPrefix}{AuthControllerPrefix}sign-in";
        public const string TestAuthEndpoint = $"{BaseControllerPrefix}{AuthControllerPrefix}";
    }
}
