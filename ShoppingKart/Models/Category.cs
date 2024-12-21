using System.ComponentModel.DataAnnotations;

namespace FirstMVCapp.Models
{
    public class Category
    {

        public required int Id { get; set; }

        [Required(ErrorMessage = "Enter Proper Name!")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Enter Proper Taxrate!")]
        public decimal TaxRate { get; set; }

    }
}
