using System.ComponentModel.DataAnnotations;

namespace MvcGroceryMangement.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string ProductTitle { get; set; }

        public String ProductDesc { get; set; }

        public int Price { get; set; }
        public int TotalAmount { get; set; } = 100;

    }
}
