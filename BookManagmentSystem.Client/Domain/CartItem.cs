using System.ComponentModel.DataAnnotations;

namespace BookManagmentSystem.Client.Domain
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
