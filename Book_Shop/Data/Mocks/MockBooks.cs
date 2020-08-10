using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.Mocks
{
    public class MockBooks : IAllBooks
    {
        private readonly IAllGenres genres = new MockGenres();

        public IEnumerable<Book> Books {
            get 
            {
                return new List<Book>
                {
                    new Book{
                        BookName = "Інститут", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="fantasy"),
                        Price = 300, 
                        WriteYear= 2020, 
                        WriteLanguage = "Українська", 
                        WrittenBy = "С. Кінг", 
                        TagName = "institut", 
                        BookRate= 4.1f, 
                        CountPages= 608, 
                        ShortDesc="", 
                        LongDesc="", 
                        ImgPath=""},

                    new Book{
                        BookName = "Воно", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="fantasy"),
                        Price = 355, 
                        WriteYear= 2017,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг", 
                        TagName = "vono",
                        BookRate= 4.4f,
                        CountPages= 1344, 
                        ShortDesc="", 
                        LongDesc="", 
                        ImgPath=""},
                    
                    new Book{
                        BookName = "Аутсайдер", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="fantasy"),
                        Price = 245, 
                        WriteYear= 2019,
                        WriteLanguage = "Українська", 
                        WrittenBy = "С. Кінг", 
                        TagName = "autsayder",
                        BookRate= 4.7f, 
                        CountPages= 592, 
                        ShortDesc="", 
                        LongDesc="", 
                        ImgPath=""},
                    //---------------------------------------------
                    new Book{
                        BookName = "На крилах мрії", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="love_novels"),
                        Price = 190, 
                        WriteYear= 2020, 
                        WriteLanguage = "Українська",
                        WrittenBy = "Джоджо Мойєс", 
                        TagName = "na-krilah-mriyi",
                        BookRate= 3.9f, 
                        CountPages= 512, 
                        ShortDesc="", 
                        LongDesc="", 
                        ImgPath=""},

                    new Book{
                        BookName = "Похищение как повод для романа", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="love_novels"),
                        Price = 150, 
                        WriteYear= 2020, 
                        WriteLanguage = "Російська", 
                        WrittenBy = "Н. Соболевская",
                        TagName = "pohishchenie-kak-povod-dlya-romana",
                        BookRate= 3.5f, 
                        CountPages= 320, 
                        ShortDesc="",
                        LongDesc="", 
                        ImgPath=""},

                    new Book{BookName = "Жених напрокат", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="love_novels"),
                        Price = 129,
                        WriteYear= 2020, 
                        WriteLanguage = "Російська",
                        WrittenBy = "М. Комарова", 
                        TagName = "jenih-naprokat",
                        BookRate= 3.3f, 
                        CountPages= 288, 
                        ShortDesc="",
                        LongDesc="", 
                        ImgPath=""},
                    //---------------------------------------------
                    new Book{BookName = "Адвокат диявола",
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="horrors"),
                        Price = 109,
                        WriteYear= 2019,
                        WriteLanguage = "Українська",
                        WrittenBy = "Е. Нейдерман", 
                        TagName = "advokat-diyavola",
                        BookRate= 4.2f,
                        CountPages= 288,
                        ShortDesc="", 
                        LongDesc="",
                        ImgPath=""},

                    new Book{BookName = "Містер Мерседес", 
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="horrors"),
                        Price = 240, 
                        WriteYear= 2020, 
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг",
                        TagName = "mister-mersedes",
                        BookRate= 4.6f, 
                        CountPages= 544, 
                        ShortDesc="", 
                        LongDesc="", 
                        ImgPath=""},

                    new Book{BookName = "Похищение Энни Торн",
                        BookGenre = genres.AllGenres.FirstOrDefault(c => c.TagName=="horrors"),
                        Price = 187, 
                        WriteYear= 2019,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Дж. Тюдор",
                        TagName = "pohishchenie-enni-torn",
                        BookRate= 4.0f,
                        CountPages= 288,
                        ShortDesc="", 
                        LongDesc="",
                        ImgPath="" }
                };
            }
        }

        // Метод для отримання списку найпопулярніших книг
        public IEnumerable<Book> GetBestBook { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Метод для отримання екземпляру книги по його id
        public Book GetObject(int BookId)
        {
            return Books.FirstOrDefault(c => c.Id==BookId);
        }
    }
}
