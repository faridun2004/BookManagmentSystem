﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Infrastructure.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "BookServer";
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "2EC1EE51-1100-4347-BF22-EEB6CB8B0695";   // ключ для шифрации
        public const int LIFETIME = 30; // время жизни токена - 15 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }

}
