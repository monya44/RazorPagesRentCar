using System.ComponentModel.DataAnnotations;

namespace RazorPagesRentCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field cannot be null! Please, write the name")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string PhotoPath { get; set; }
        public Dist? District { get; set; }

    }
}
