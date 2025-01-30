using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFinalProject.Models;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CarsController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult TestDatabase()
    {
        var count = _context.Cars.Count();
        return Content($"Veritabanında {count} kayıt var.");
    }


    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _context.Cars.ToListAsync();
        return Ok(cars);
    }

  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> PostCar([FromBody] Car car)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, [FromBody] Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        _context.Entry(car).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
