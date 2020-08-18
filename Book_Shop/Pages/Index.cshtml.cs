using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Book_Shop.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> AllBooks { get; set; } // Використовується при відображенні всіх книг

        private readonly IAllBooks _allBooks;

        public IndexModel(IAllBooks allBooks)
        {
            _allBooks = allBooks;
        }

        public void OnGet()
        {
            AllBooks = _allBooks.Books.OrderByDescending(c => c.BookRate);
        }
    }
}
