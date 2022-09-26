using System;
using System.Collections.Generic;

namespace WebAPIConcept.Models
{
    public partial class Grocery
    {
        public int Id { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductDesc { get; set; }
        public int? Price { get; set; }
        public int? Userid { get; set; }

        public virtual Usertbl? User { get; set; }
    }
}
