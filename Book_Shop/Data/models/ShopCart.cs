using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; } // id замовлення

        public List<ShopCartItem> ListShopItems { get; set; } // список замовлених товарів

        public AppDBContext AppDBContent { get; } // об'єкт бази даних

        public ShopCart(AppDBContext appDBContent) // ініціалізація бази даних
        {
            this.AppDBContent = appDBContent;
        }

        // метод отримання замовлення
        public static ShopCart GetCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); // ?? повертає лівий операнд, якщо він
                                                                                          // не рівний null, якщо ні, повертає правий
                                                                                          // Guid.NewGuid() повертає рандомний унікальний ідентифікатор
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        // додати у замовлення товар
        public void AddToCart(Book book)
        {
            this.AppDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Book = book,
                Price = book.Price
            });

            AppDBContent.SaveChanges();
        }

        // видалити товар із замовлення
        public void RemoveFromCart(int Id)
        {
            ShopCartItem item = AppDBContent.ShopCartItems.FirstOrDefault(c => c.Id == Id);

            if (item != null)
            {
                AppDBContent.ShopCartItems.Remove(item);
            }

            AppDBContent.SaveChanges();
        }

        // отримати список елементів замовлення включаючи екземпляр замовленої книги
        public List<ShopCartItem> GetShopItems()
        {
            return AppDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Book).ThenInclude(q => q.BookGenre).ToList();
        }

        // видалити список покупок одного користувача(за ShopCartId) 
        public void DeleteShopCart(string shopCartId)
        {
            List<ShopCartItem> items = AppDBContent.ShopCartItems.Where(c => c.ShopCartId == shopCartId).ToList();

            if (items.Count != 0)
            {
                AppDBContent.ShopCartItems.RemoveRange(items);
            }

            AppDBContent.SaveChanges();
        }
    }
}
