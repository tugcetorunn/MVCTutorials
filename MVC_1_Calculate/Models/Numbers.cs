using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_1_Calculate.Models
{
    public class Numbers
    {
        [Display(Name = "Enter the first number")]
        [Required(ErrorMessage = "First number can not be empty!")]
        [Range(1, 1000, ErrorMessage = "First number must be between 1 and 1000!")]
        public int FirstNumber { get; set; }
        [Display(Name = "Enter the second number")]
        [Required(ErrorMessage = "Second number can not be empty!")]
        [Range(1, 1000, ErrorMessage = "Second number must be between 1 and 1000!")]
        public int SecondNumber { get; set; }
        public int Result { get; set; }

    }
}
