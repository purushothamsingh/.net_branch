using System.ComponentModel.DataAnnotations;

namespace CrudMvc.Models
{
    public class Category
    {
        [Key]
       public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(1,100,ErrorMessage ="Display Order between 1,100 only..")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now; 


    }
}
