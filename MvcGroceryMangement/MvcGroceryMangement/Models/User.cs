using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcGroceryMangement.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
