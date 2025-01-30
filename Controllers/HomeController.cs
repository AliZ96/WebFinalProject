using Microsoft.AspNetCore.Mvc;
using WebFinalProject.Models;
using System.Linq;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search, string brand, string transmission, string sortPrice)
        {
            var cars = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                cars = cars.Where(c => c.Make.Contains(search) || c.Model.Contains(search));

            if (!string.IsNullOrEmpty(brand))
                cars = cars.Where(c => c.Make == brand);

            if (!string.IsNullOrEmpty(transmission))
                cars = cars.Where(c => c.Transmission == transmission);

            if (!string.IsNullOrEmpty(sortPrice))
            {
                cars = sortPrice == "asc" ? cars.OrderBy(c => c.Price) : cars.OrderByDescending(c => c.Price);
            }

            return View(cars.ToList());
        }

        public IActionResult AddCar()
        {
            return View();
        }

        public IActionResult GetOffices()
        {
            var offices = _context.Offices
                .Select(o => new
                {
                    o.Id,
                    o.Name,
                    o.Address,
                    o.Latitude,
                    o.Longitude
                }).ToList();

            return Json(offices);
        }
    }
}
