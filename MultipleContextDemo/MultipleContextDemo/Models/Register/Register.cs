using System.ComponentModel.DataAnnotations;

namespace MultipleContextDemo.Models.Register
{
    public class Register
    {

        [Key]
        public int Id { get; set; }

        public string RegisterUserName { get; set; }

        public string RegisterPassword { get; set; }
    }
}
