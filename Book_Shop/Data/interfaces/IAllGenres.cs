using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.interfaces
{
    // інтерфейс для масштабування додавання нових жанрів
    public interface IAllGenres
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
