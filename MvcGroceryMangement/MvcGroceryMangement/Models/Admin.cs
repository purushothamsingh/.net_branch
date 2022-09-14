using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MvcGroceryMangement.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Admin_UserName { get; set; }

        [Required]
        public string Admin_Password { get; set; }

    }
}
