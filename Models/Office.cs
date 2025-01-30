using System.ComponentModel.DataAnnotations;

namespace WebFinalProject.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
