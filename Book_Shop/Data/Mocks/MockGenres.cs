using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Book_Shop.Data.Mocks
{
    public class MockGenres : IAllGenres
    {
        public IEnumerable<Genre> AllGenres
        {
            get
            {
                return new List<Genre> {
                    new Genre {ImgPath="", GenreName = "Жахи, трилери", TagName = "horrors", Desc = "Захоплюючі історії для тих, хто не проти полоскотати свої нерви. Психологічні, детективні та містичні трилери, хоррор, книги, за якими були зняті найкращі фільми жахів." },
                    new Genre {ImgPath="", GenreName = "Любовні романи", TagName = "love_novels", Desc = "Для вас — дивовижні історії кохання, від романтичних до найвідвертіших. Відомі автори та нові імена. Заборонені бажання, королівські таємниці, фатальна пристрасть, сімейні саги, захоплюючі любовні пригоди."},
                    new Genre {ImgPath="", GenreName = "Фентезі", TagName = "fantasy", Desc = "У цьому розділі зібрані найкращі твори у фентезійному жанрі. Небезпечні пригоди і чарівні істоти чекають на свого читача, щоб віднести його у створений автором світ. Якщо й тікати від реальності, то тільки у книги! Будьте тим, ким завжди мріяли стати: ельфом, чарівником чи тролем — все обмежується лише вашою уявою."}
                };
            }
        }
    }
}
