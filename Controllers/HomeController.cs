using GraduationProject.Data;
using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(double price = 0, int rate = 0, int? location = null)
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel

            {
                Cards = _context.Cards.ToList(),
                Locations = _context.Locations.ToList(),
                Cities=_context.Cities.ToList(),
            };

            if (price > 0)
                homePageViewModel.Cards = homePageViewModel.Cards.Where(x => x.Price == price).ToList();

            if (rate > 0)
                homePageViewModel.Cards = homePageViewModel.Cards.Where(x => x.Rate == rate).ToList();

            if (location != null)
                homePageViewModel.Cards = homePageViewModel.Cards.Where(x => x.locationFk == location).ToList();

            return View(homePageViewModel);
        }

        public IActionResult Details(int id)
        {
            var result = _context.Details.FirstOrDefault(x => x.CardId == id);
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}