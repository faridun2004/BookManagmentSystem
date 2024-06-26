using BookManagmentSystem.Client.Domain;
using System.Net.Http.Json;

namespace BookManagmentSystem.Client.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Author>>("api/authors");
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Author>($"api/authors/{id}");
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authors", author);
            return await response.Content.ReadFromJsonAsync<Author>();
        }

        public async Task<Author> UpdateAuthorAsync(Guid id, Author author)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/authors/{id}", author);
            return await response.Content.ReadFromJsonAsync<Author>();
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/authors/{id}");
        }
    }
}
