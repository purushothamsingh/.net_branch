using System.ComponentModel.DataAnnotations;

namespace CrudMvc.Models
{
    public class Userstools
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
