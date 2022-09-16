namespace MvcGroceryMangement.Models
{
    public class GroceryProducts
    {

        public int Id { get; set; }

        public string ProductTitle { get; set; }

        public string ProdImgUrl { get; set; }

        public String ProductDesc { get; set; }

        public int Price { get; set; }

        public User User { get; set; }
    }
}
