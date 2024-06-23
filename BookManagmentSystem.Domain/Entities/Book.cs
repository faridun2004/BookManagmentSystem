using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
