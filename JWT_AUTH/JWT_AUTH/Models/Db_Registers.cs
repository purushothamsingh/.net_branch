using System.ComponentModel.DataAnnotations;

namespace JWT_AUTH.Models
{
    public class Db_Registers
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PaswordSalt { get; set; }
        public string Email { get; set; } = "dummy@gmail.com";
        //[Compare("Password")]
        //public byte[] ConfirmPassword {get; set; }
        // public string Email { get; set; }

        public string Role { get; set; } = "user";
        public bool IsRegister = false;
    }
}
