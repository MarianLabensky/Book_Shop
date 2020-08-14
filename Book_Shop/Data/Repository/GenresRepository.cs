using Book_Shop.Data.interfaces;
using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.Repository
{
    public class GenresRepository : IAllGenres
    {
        public AppDBContext AppDBContext { get; }

        public GenresRepository(AppDBContext appDBContent)
        {
            this.AppDBContext = appDBContent;
        }

        public IEnumerable<Genre> AllGenres => AppDBContext.Genres;
    }
}
