using Book_Shop.Data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
