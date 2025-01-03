﻿namespace MotorSocialApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public Guid UserId { get; set; } // Kullanıcı ID'sini ekledik
    }
}
