using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private AppDBContext AppDBContext { get; set; }

        public ShopCart ShopCart { get; set; }

        public OrdersRepository(AppDBContext appDBContext, ShopCart ShopCart)
        {
            this.AppDBContext = appDBContext;
            this.ShopCart = ShopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            AppDBContext.Orders.Add(order);
            AppDBContext.SaveChanges();

            var items = ShopCart.GetShopItems();

            foreach (var item in items)
            {
                var elem = new OrderItem
                {
                    Price = item.Price,
                    BookId = item.Id,
                    OrderId = order.Id
                };
                AppDBContext.OrderItems.Add(elem);
            }

            AppDBContext.SaveChanges();
        }
    }
}
