using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data
{
    public class AddToDB
    {
        public static void Initial(AppDBContext content)
        {

            if (!content.Genres.Any())
            {
                content.Genres.AddRange(Genres.Select(c => c.Value));
            }

            if (!content.Books.Any())
            {
                content.Books.AddRange(
                    new Book
                    {
                        BookName = "Інститут",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "fantasy"),
                        Price = 300,
                        WriteYear = 2020,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг",
                        TagName = "institut",
                        BookRate = 4.1f,
                        CountPages = 608,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/institut.jpg"
                    },

                    new Book
                    {
                        BookName = "Воно",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "fantasy"),
                        Price = 355,
                        WriteYear = 2017,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг",
                        TagName = "vono",
                        BookRate = 4.4f,
                        CountPages = 1344,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/vono.jpg"
                    },

                    new Book
                    {
                        BookName = "Аутсайдер",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "fantasy"),
                        Price = 245,
                        WriteYear = 2019,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг",
                        TagName = "autsayder",
                        BookRate = 4.7f,
                        CountPages = 592,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/autsayder.jpg"
                    },
                    //---------------------------------------------
                    new Book
                    {
                        BookName = "На крилах мрії",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "love_novels"),
                        Price = 190,
                        WriteYear = 2020,
                        WriteLanguage = "Українська",
                        WrittenBy = "Джоджо Мойєс",
                        TagName = "na-krilah-mriyi",
                        BookRate = 3.9f,
                        CountPages = 512,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/na-krilah-mriyi.jpg"
                    },

                    new Book
                    {
                        BookName = "Похищение как повод для романа",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "love_novels"),
                        Price = 150,
                        WriteYear = 2020,
                        WriteLanguage = "Російська",
                        WrittenBy = "Н. Соболевская",
                        TagName = "pohishchenie-kak-povod-dlya-romana",
                        BookRate = 3.5f,
                        CountPages = 320,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/pohishchenie-kak-povod-dlya-romana.jpg"
                    },

                    new Book
                    {
                        BookName = "Жених напрокат",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "love_novels"),
                        Price = 129,
                        WriteYear = 2020,
                        WriteLanguage = "Російська",
                        WrittenBy = "М. Комарова",
                        TagName = "jenih-naprokat",
                        BookRate = 3.3f,
                        CountPages = 288,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/jenih-naprokat.jpg"
                    },
                    //---------------------------------------------
                    new Book
                    {
                        BookName = "Адвокат диявола",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "horrors"),
                        Price = 109,
                        WriteYear = 2019,
                        WriteLanguage = "Українська",
                        WrittenBy = "Е. Нейдерман",
                        TagName = "advokat-diyavola",
                        BookRate = 4.2f,
                        CountPages = 288,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/advokat-diyavola.jpg"
                    },

                    new Book
                    {
                        BookName = "Містер Мерседес",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "horrors"),
                        Price = 240,
                        WriteYear = 2020,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Кінг",
                        TagName = "mister-mersedes",
                        BookRate = 4.6f,
                        CountPages = 544,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/mister-mersedes.jpg"
                    },

                    new Book
                    {
                        BookName = "Похищение Энни Торн",
                        BookGenre = Genres.Values.FirstOrDefault(c => c.TagName == "horrors"),
                        Price = 187,
                        WriteYear = 2019,
                        WriteLanguage = "Українська",
                        WrittenBy = "С. Дж. Тюдор",
                        TagName = "pohishchenie-enni-torn",
                        BookRate = 4.0f,
                        CountPages = 288,
                        ShortDesc = "",
                        LongDesc = "",
                        ImgPath = "/img/pohishchenie-enni-torn.jpg"
                    });
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Genre> genres;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    List<Genre> list = new List<Genre>
                    {
                    new Genre {ImgPath="", GenreName = "Жахи, трилери", TagName = "horrors", Desc = "Захоплюючі історії для тих, хто не проти полоскотати свої нерви. Психологічні, детективні та містичні трилери, хоррор, книги, за якими були зняті найкращі фільми жахів." },
                    new Genre {ImgPath="", GenreName = "Любовні романи", TagName = "love_novels", Desc = "Для вас — дивовижні історії кохання, від романтичних до найвідвертіших. Відомі автори та нові імена. Заборонені бажання, королівські таємниці, фатальна пристрасть, сімейні саги, захоплюючі любовні пригоди."},
                    new Genre {ImgPath="", GenreName = "Фентезі", TagName = "fantasy", Desc = "У цьому розділі зібрані найкращі твори у фентезійному жанрі. Небезпечні пригоди і чарівні істоти чекають на свого читача, щоб віднести його у створений автором світ. Якщо й тікати від реальності, то тільки у книги! Будьте тим, ким завжди мріяли стати: ельфом, чарівником чи тролем — все обмежується лише вашою уявою."}
                };

                genres = new Dictionary<string, Genre>();
                    foreach (Genre item in list)
                    {
                        genres.Add(item.TagName, item);
                    }
                }
                return genres;
            }

        }

    }
}
