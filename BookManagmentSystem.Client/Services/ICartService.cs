using BookManagmentSystem.Client.Domain;

namespace BookManagmentSystem.Client.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart();
        Task AddToCart(CartItem item);
        Task RemoveFromCart(int productId);
        Task ClearCart();
        Task UpdateQuantity(int productId, int newQuantity);
    }
}
