using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class Genre
    {
        public int Id { get; set; } // унікальний ідентифікатор кожного жанру

        public string GenreName { get; set; } // ім'я жанру

        public string TagName { get; set; } // Як буде записано в шляху(обов'язково на англійській і без пробілів!!)

        public string Desc { get; set; } // Опис жанру

        public string ImgPath { get; set; } // Посилання на фотографію обкладинки жанру

        public List<Book> Books { get; set; } // Список книг, які відносяться до даного жанру

    }
}
