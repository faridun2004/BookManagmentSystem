﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class OrderItemDto
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}
