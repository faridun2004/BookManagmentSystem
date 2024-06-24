using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class Cart 
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }
        }
    }
}
