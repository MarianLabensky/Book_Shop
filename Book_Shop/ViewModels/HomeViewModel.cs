using Book_Shop.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BestBooks { get; set; }
    }
}
