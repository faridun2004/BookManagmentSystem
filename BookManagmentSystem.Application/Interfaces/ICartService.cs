using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Interfaces
{
    public interface ICartService
    {
        Cart GetCart();
        void AddToCart(CartItem item);
        void RemoveFromCart(int productId);
        void ClearCart();
        void UpdateQuantity(int productId, int newQuantity);
    }
}
