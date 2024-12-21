//Currently Not in use.
using System.ComponentModel.DataAnnotations;

namespace FirstMVCapp.Models
{
    public class Customer
    {

        public required int Id { get; set; }

        [Required(ErrorMessage ="Enter Proper Name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Proper Address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Proper Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Proper PhoneNumber!")]
        public decimal PhoneNum { get; set; }

    }
}
