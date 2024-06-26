﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Book>  Books { get; set; }
    }
}
