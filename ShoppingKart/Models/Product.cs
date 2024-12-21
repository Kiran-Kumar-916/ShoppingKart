using System.ComponentModel.DataAnnotations;

namespace FirstMVCapp.Models
{
    public class Product
    {

        public required int Id { get; set; }

        [Required(ErrorMessage ="Enter Proper Name!")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Enter Proper Category!")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Enter Proper Price!")]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public int Quantity { get; set; }

    }
}
