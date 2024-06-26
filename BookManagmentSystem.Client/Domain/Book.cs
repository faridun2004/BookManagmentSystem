namespace BookManagmentSystem.Client.Domain
{
    public class Book
    {
        public Guid Id { get; set; }    
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
