using EventPilotWeb.Domain;
using EventPilotWeb.Infraestructure;
using EventPilotWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EventPilotWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            User user1 = new()
            {
                FirstName = "eee",
                LastName = "bbb"
            };

            dbContext.Users.Add(user1);

            Profile profile = new() { Owner = user1 };

            dbContext.Profiles.Add(profile);

            dbContext.SaveChanges();

            return View();
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