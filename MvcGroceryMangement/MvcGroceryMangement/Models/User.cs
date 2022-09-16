using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcGroceryMangement.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
