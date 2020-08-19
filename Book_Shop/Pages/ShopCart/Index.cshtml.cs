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
    public class IndexModel : PageModel
    {

        private readonly Data.models.ShopCart _shopCart;

        public Data.models.ShopCart ShopCart { get; set; }

        public IndexModel( Data.models.ShopCart shopCart)
        {

            _shopCart = shopCart;
        }

        public void OnGet()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            ShopCart = _shopCart;
        }


    }
}
