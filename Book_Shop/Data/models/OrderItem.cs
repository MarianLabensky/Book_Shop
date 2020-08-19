using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    // клас кожного замовленого елементу(в даному випадку книги)
    public class OrderItem
    {
        public int Id { get; set; } 

        public int OrderId { get; set; } 

        public int BookId { get; set; }

        public float Price { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
