using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class Order
    {
        public int Id { get; set; } 

        public string FirstName { get; set; } //required

        public string LastName { get; set; } //required

        public string Email { get; set; }

        public string Phone { get; set; } //required

        public string Address { get; set; } //required

        public DateTime OrderDate { get; set; }  //required

        public List<OrderItem> OrderItems { get; set; } // список елементів замовлення
    }
}
