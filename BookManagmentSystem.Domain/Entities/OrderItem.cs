using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public double Quantity { get; set; }
    }
}
