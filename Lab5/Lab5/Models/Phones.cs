using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Phones
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter phone name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter phone brend")]
        public string Brend { get; set; }

        [Range(0.00, 9999999.99, ErrorMessage = "Price must be correct")]
        [Required(ErrorMessage = "Enter phone price")]
        public decimal Price { get; set; }
    }
}
