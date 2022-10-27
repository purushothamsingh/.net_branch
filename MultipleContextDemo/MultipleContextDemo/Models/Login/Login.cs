using System.ComponentModel.DataAnnotations;

namespace MultipleContextDemo.Models.Login
{
    public class Login
    {

        [Key]
        public string UserNameLogin { get; set; }

        public string PasswordLogin { get; set; }

    }
}
