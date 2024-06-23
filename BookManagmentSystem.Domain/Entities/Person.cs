using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public  class Person : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";

        public string? Address { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public bool IsBlocked {  get; set; }
        
    }
}
