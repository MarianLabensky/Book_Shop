using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Shop.Pages.Books
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> AllBooks { get; set; } // Використовується при відображенні всіх книг

        public Book PageBook { get; set; } // Використовується при відображенні сторінки з ОДНОЮ КНИГОЮ

        public Genre PageGenre { get; set; } // Використовується при відображенні книг ПЕВНОГО ЖАНРУ

        private readonly IAllBooks _allBooks;

        private readonly IAllGenres _allGenres;

        [BindProperty(SupportsGet = true)]
        public string genre { get; set; } // назва жанру, отриманого з url-строки
        [BindProperty(SupportsGet = true)]
        public string bookName { get; set; } // назва книги, отриманої з url-строки

        public string CurrentCatalog { get; set; }

        public IndexModel(IAllBooks allBooks, IAllGenres allGenres)
        {
            _allBooks = allBooks;

            _allGenres = allGenres;
        }

        public void OnGet()
        {
            if (bookName == null && genre == null)
            {
                AllBooks = _allBooks.Books.OrderByDescending(c => c.BookRate);
                CurrentCatalog = "Найкращі книги";
            }
            else if (bookName == null && genre != null)
            {
                AllBooks = _allBooks.Books.Where(c => c.BookGenre.TagName == genre).OrderByDescending(c => c.BookRate);
                PageGenre = _allGenres.AllGenres.FirstOrDefault(c => c.TagName == genre);
                CurrentCatalog = PageGenre.GenreName;
            }
            else
            {
                PageBook = _allBooks.Books.FirstOrDefault(c => c.TagName == bookName);
            }
        }


    }
}