using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class Book
    {
        public int Id { get; set; } // унікальне id кожної книги

        public string BookName { get; set; } // Назва книги

        public string TagName { get; set; } // Як буде записано в шляху(обов'язково на англійській і без пробілів!!)
 
        public Genre BookGenre { get; set; } // Жанр

        public string WrittenBy { get; set; } // Ким написана

        public float Price { get; set; } // Ціна

        public int WriteYear { get; set; } // Рік написання

        public int CountPages { get; set; } // Кількість сторінок

        public string ImgPath { get; set; } // Шлях до картинки з книгою

        public string WriteLanguage { get; set; } // Мова, на якій написана

        public string ShortDesc { get; set; }   // Короткий опис

        public string LongDesc { get; set; } // Довгий опис

        public int GenreId { get; set; } // ідентифікатор жанру

        public float BookRate { get; set; } // Рейтинг книги серед читачів  
    }
}
