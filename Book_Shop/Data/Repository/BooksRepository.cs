using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.Repository
{
    public class BooksRepository : IAllBooks
    {
        public AppDBContext AppDBContext { get; }

        public BooksRepository(AppDBContext appDBContext)
        {
            this.AppDBContext = appDBContext;
        }

        public IEnumerable<Book> Books => AppDBContext.Books.Include(c => c.BookGenre);

        // Метод для отримання списку найпопулярніших книг
        public IEnumerable<Book> GetBestBook => AppDBContext.Books.Where(c => c.BookRate > 4).OrderByDescending(c => c.BookRate).Include(c => c.BookGenre);

        // Метод для отримання екземпляру книги по його id
        public Book GetObject(int BookId)
        {
            return Books.FirstOrDefault(c => c.Id == BookId);
        }
    }
}
