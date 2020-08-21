using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Shop.Data;
using Book_Shop.Data.models;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.Repository;

namespace Book_Shop.Pages.ShopCart
{
    //Delete

    public class IndexModel : PageModel
    {

        private readonly Data.models.ShopCart _shopCart;
        private readonly IAllBooks _bookRepository;

        //Вартість всіх товарів в корзині
        public float AllPrice {
            get
            {
                float allPrice = 0;
                if (ShopCart.ListShopItems.Count != 0)
                {
                    foreach (var item in ShopCart.ListShopItems)
                    {
                        allPrice += item.Price;
                    }
                }
                return allPrice;
            }
        }

        // повідомлення про те, що корзина пуста(випливає коли корзина пуста)
        public string MessageEmptyCart { get; set; } = "Вибачте, але корзина пуста.";

        // Текст посилання для покупок(випливає коли корзина пуста)
        public string MessageLinkForBuy { get; set; } = "Це потрібно виправити!";

        //  публічний екземпляр корзини, в якому зберігаються додані товари
        public Data.models.ShopCart ShopCart { get; set; } 

        public IndexModel(IAllBooks bookRepository, Data.models.ShopCart shopCart)
        {
            _bookRepository = bookRepository;
            _shopCart = shopCart;
        }

        public void OnGet()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            ShopCart = _shopCart;
        }

        public void OnGetAdd(int id)
        {
           var item = _bookRepository.Books.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            OnGet();
        }

        public void OnPostRemove(int Id)
        {
            _shopCart.RemoveFromCart(Id);
            
            OnGet();
        }



    }
}
