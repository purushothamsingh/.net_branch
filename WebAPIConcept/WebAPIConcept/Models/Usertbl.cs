using System;
using System.Collections.Generic;

namespace WebAPIConcept.Models
{
    public partial class Usertbl
    {
        public Usertbl()
        {
            Groceries = new HashSet<Grocery>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Grocery> Groceries { get; set; }
    }
}
