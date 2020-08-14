using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Shop.Pages.Genres
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Genre> AllGenres;

        public IEnumerable<Book> AllBooks;

        public IndexModel(IAllGenres allGenres, IAllBooks allBooks)
        {
            AllBooks = allBooks.Books;
            AllGenres = allGenres.AllGenres; 
        }

        public void OnGet()
        { 
            // Потрібно занести в кожен жанр свою фотографію, яка буде відображатись на сторінці
            // Вона дорівнює фотографії найкращої книги(по рейтингу) в списку даного жанру 
           AllGenres.ToList().ForEach(c => {
                c.ImgPath = AllBooks
                .Where(i => i.BookGenre.TagName == c.TagName) // знаходимо книги, які відносяться до жанру с
                .OrderByDescending(z => z.BookRate) // впорядковуємо за спаданням
                .First() // вибираємо першу(найкращу по рейтингу) книгу
                .ImgPath; // і прирівнюємо шлях до картинки книги шляху до картинки жанру

            }) ;

            var j = AllGenres; 
        }
    }
}