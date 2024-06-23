using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }
        public Guid  CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }

    }
}
