using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Shop.Pages.Books
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> AllBooks { get; set; } // Використовується при відображенні всіх книг

        public Book PageBook { get; set; } // Використовується при відображенні сторінки з ОДНОЮ КНИГОЮ

        public Genre PageGenre { get; set; } // Використовується при відображенні книг ПЕВНОГО ЖАНРУ

        // список елементів селектору
        private string[] source = { "За рейтингом", "За роком видання", "За ціною: від дорогих", "За ціною: від дешевих" };

        private string CurrentSelector { get; set; } // змінна, для визначення типу селектору,
                                                                // за замовчуванням (за рейтингом)

        public SelectList SortSelector { get; set; } // змінна в якій зберігаються елементи селектору

        private readonly IAllBooks _allBooks;

        private readonly IAllGenres _allGenres;

        [BindProperty(SupportsGet = true)]
        public string genre { get; set; } // назва жанру, отриманого з url-строки
        [BindProperty(SupportsGet = true)]
        public string bookName { get; set; } // назва книги, отриманої з url-строки

        public string CurrentCatalog { get; set; } = "Всі книги";

        public IndexModel(IAllBooks allBooks, IAllGenres allGenres)
        {
            _allBooks = allBooks;

            _allGenres = allGenres;

            AllBooks = _allBooks.Books;
        }

        public void OnGet()
        {
            if (bookName == null) 
            {
               SortSelector = new SelectList(source, source[0]);

                if (genre == null)
                {
                    AllBooks = _allBooks.Books.OrderByDescending(c => c.BookRate);
                }
                else
                {
                    AllBooks = _allBooks.Books.Where(c => c.BookGenre.TagName == genre).OrderByDescending(c => c.BookRate);
                    PageGenre = _allGenres.AllGenres.FirstOrDefault(c => c.TagName == genre);
                    CurrentCatalog = PageGenre.GenreName;
                }
            }
            else
            {
                PageBook = _allBooks.Books.FirstOrDefault(c => c.TagName == bookName);
            }
        }

        public void OnPost(string sortSelector)
        {
            if (genre != null)
            {
                AllBooks = AllBooks.Where(c => c.BookGenre.TagName == genre);
                PageGenre = _allGenres.AllGenres.FirstOrDefault(c => c.TagName == genre);
                CurrentCatalog = PageGenre.GenreName;
            }

            switch (sortSelector)
            {
                case "За роком видання":
                    AllBooks = AllBooks.OrderByDescending(c => c.WriteYear);
                    CurrentSelector = source[1];
                    break;
                case "За ціною: від дорогих":
                    AllBooks = AllBooks.OrderByDescending(c => c.Price);
                    CurrentSelector = source[2];
                    break;
                case "За ціною: від дешевих":
                    AllBooks = AllBooks.OrderBy(c => c.Price);
                    CurrentSelector = source[3];
                    break;
                default:
                    AllBooks = AllBooks.OrderByDescending(c => c.BookRate);
                    CurrentSelector = source[0];
                    break;
            }

            SortSelector = new SelectList(source, CurrentSelector);

        }
    }
}