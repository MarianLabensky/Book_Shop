using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Shop.Data.interfaces;
using Book_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBooks _bookRepository;

        public HomeController(IAllBooks bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var homeBooks = new HomeViewModel { BestBooks = _bookRepository.GetBestBook };
            return View(homeBooks);
        }
    }
}
