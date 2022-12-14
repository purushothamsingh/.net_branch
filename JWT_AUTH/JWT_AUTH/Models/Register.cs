using System.ComponentModel.DataAnnotations;

namespace JWT_AUTH.Models
{
    public class Register
    {


        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; } = "dummy@gmail.com";
        //[Compare("Password")]
        //public byte[] ConfirmPassword {get; set; }
        // public string Email { get; set; }

        public string Role { get; set; } = "user";
        public bool IsRegister = false;
    }
}
