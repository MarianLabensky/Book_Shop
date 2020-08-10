using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IAllGenres _allGenres;

        // В даному методі передаються об'єкти інтерфейсів з їхньою реалізацією
        public BooksController(IAllBooks allBooks, IAllGenres allGenres)
        {
            _allBooks = allBooks;
            _allGenres = allGenres;
        }


        // Метод повертає сторінку з кодом
        public IActionResult Index() 
        {
            var books = _allBooks.Books;
            return View(books);
        }
    }
}
