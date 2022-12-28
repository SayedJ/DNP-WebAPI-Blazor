using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Child
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required"), MaxLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Name{ get; set; }
        [Required(ErrorMessage ="Age is Required"), Range(3, 6, ErrorMessage ="must be between 3 - 6")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Gender is Required")]
        public string Gender { get; set; }

        public ICollection<Toy> Toys { get; set; }


    }

    
}
