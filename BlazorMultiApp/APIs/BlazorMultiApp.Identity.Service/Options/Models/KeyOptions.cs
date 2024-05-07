﻿namespace BlazorMultiApp.Identity.Service.Options.Models
{
    public class KeyOptions
    {
        public string PrivateKey { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
