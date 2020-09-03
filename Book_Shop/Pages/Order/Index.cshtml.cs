using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Shop.Pages.Order
{
    public class IndexModel : PageModel
    {


        private IAllOrders AllOrders { get; }
        public Data.models.ShopCart ShopCart { get; }
        public Data.models.Order Order { get; set; }

        public string CompleteMessage { get; set; } // повідомлення після успішного оформлення

        public IndexModel(IAllOrders allOrders, Data.models.ShopCart shopCart)
        {
            AllOrders = allOrders;
            ShopCart = shopCart;
        }

        public void OnGet()
        {
        }

        public void OnPost(Data.models.Order order)
        {
            ShopCart.ListShopItems = ShopCart.GetShopItems();

            if (ShopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Щоб замовити товари, їх необхідно додати в корзину!");
            }

            if (ModelState.IsValid == true)
            {
                AllOrders.CreateOrder(order);
                ShopCart.DeleteShopCart(ShopCart.ShopCartId);
                OnGetComplete();
            }

        }

        public void OnGetComplete()
        {
           CompleteMessage = "Заказ успішно оформлений, чекайте дзвінка від нашого оператора!";
        }
    }
}
