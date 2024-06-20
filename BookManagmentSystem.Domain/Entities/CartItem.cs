using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
