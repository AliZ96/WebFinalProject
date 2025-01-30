using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFinalProject.Models;

namespace WebFinalProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public IActionResult Index()
        {
            
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetOffices()
        {
          
            var offices = await _context.Offices.ToListAsync();
           
            return Json(offices);
        }

      
        public IActionResult Filter()
        {
          
            return View();
        }

        
        
        [HttpPost]
        public IActionResult Filter(string make, string transmission, string priceRange)
        {
            
            var cars = new List<Car>
            {
                new Car { Make = "Toyota", Model = "Corolla", Price = 15000, Transmission = "Automatic", Deposit = 500, Mileage = 120000, Age = 5 },
                new Car { Make = "BMW", Model = "X5", Price = 35000, Transmission = "Manual", Deposit = 1000, Mileage = 80000, Age = 3 },
                new Car { Make = "Mercedes", Model = "E-Class", Price = 45000, Transmission = "Automatic", Deposit = 1200, Mileage = 60000, Age = 2 },
                new Car { Make = "Audi", Model = "A4", Price = 30000, Transmission = "Manual", Deposit = 800, Mileage = 100000, Age = 4 }
            };

           
            if (!string.IsNullOrEmpty(make))
                cars = cars.Where(c => c.Make == make).ToList();

            if (!string.IsNullOrEmpty(transmission))
                cars = cars.Where(c => c.Transmission == transmission).ToList();

          
            if (priceRange == "lowToHigh")
                cars = cars.OrderBy(c => c.Price).ToList();
            else if (priceRange == "highToLow")
                cars = cars.OrderByDescending(c => c.Price).ToList();

            
            return Json(cars);
        }
    }
}
