using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Id:{Id} ({GetType().Name})";
        }
    }
}
