using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public float Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
