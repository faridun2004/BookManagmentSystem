using BookManagmentSystem.Client.Domain;

namespace BookManagmentSystem.Client.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Guid id, Author author);
        Task DeleteAuthorAsync(Guid id);
    }
}
