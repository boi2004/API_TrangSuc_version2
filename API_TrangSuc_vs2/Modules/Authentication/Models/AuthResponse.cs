﻿namespace API_TrangSuc_vs2.Modules.Authentication.Models
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
