using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class Toy
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Name is Required"), MaxLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Name { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public bool IsFavourite { get; set; }
    }
}
