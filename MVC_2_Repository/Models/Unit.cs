using System.ComponentModel.DataAnnotations;

namespace MVC_2_Repository.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(75)]
        public string Description { get; set; }
    }
}
