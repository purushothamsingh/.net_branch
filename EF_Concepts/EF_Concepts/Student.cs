using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_Concepts
{
    public class Student
    {
        [Key]
        public int S_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string S_Name { get; set; }

        [Required]
        [MaxLength(120)]
        public int S_age { get; set; }

        [Required, MaxLength(10)]
        public int Sage_Phone { get; set; }
            



    }
}
