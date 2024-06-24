﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookManagmentSystem.Infrastructure.Helpers
{
    internal class AuthOptions
    {
        public const string ISSUER = "BookServer";
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "2EC1EE51-1100-4347-BF22-EEB6CB8B0695";   // ключ для шифрации
        public const int LIFETIME = 330;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }

}
