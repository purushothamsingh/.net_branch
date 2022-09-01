using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EF_Concepts;

namespace EF_Concepts
{
    public class Course
    {
        [Key]
        public int C_Id { get; set; }
        [Required , MaxLength(40)]
        public string C_Name { get; set; }
        [Required]
        public int C_Cost { get; set; }

       public Student student { get; set; }

    }
}
