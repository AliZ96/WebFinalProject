using Microsoft.EntityFrameworkCore;

namespace WebFinalProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Office> Offices { get; set; }  // Ofis tablosunu ekledik
    }
}
    