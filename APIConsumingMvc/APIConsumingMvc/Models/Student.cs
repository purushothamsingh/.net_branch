using System.ComponentModel.DataAnnotations;

namespace APIConsumingMvc.Models
{
    public class Student
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string FName { get; init; }
        public string LName { get; init; }

        [Required]
        public int Age { get; init; }
    }
}
