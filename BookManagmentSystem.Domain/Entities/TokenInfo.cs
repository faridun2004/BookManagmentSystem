﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public record TokenInfo
    {
        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public DateTimeOffset ExpireTime { get; set; }
    }
}
