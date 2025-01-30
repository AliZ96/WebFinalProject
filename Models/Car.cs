using System.ComponentModel.DataAnnotations;
namespace WebFinalProject.Models;

public class Car
{
    public int Id { get; set; } // Primary Key

    [Required]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public string Transmission { get; set; }

    public double Mileage { get; set; }

    public int Age { get; set; }

    public double Deposit { get; set; }
}
