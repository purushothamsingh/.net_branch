using System.ComponentModel.DataAnnotations;

namespace demoAPi.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string username { get; set; }

        public string password { get; set; }



    }
}
