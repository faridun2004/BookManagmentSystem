using BookManagmentSystem.Client.Domain;

namespace BookManagmentSystem.Client.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllProducts();
        Task<Book> GetProductById(Guid id);
        Task AddProduct(Book book, MultipartFormDataContent content);
        Task UpdateProduct(Book book, MultipartFormDataContent content);
        Task DeleteProduct(Guid id);
    }
}
