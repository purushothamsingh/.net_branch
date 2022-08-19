using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConcept
{
    internal class LinqConcepts2
    {
        public static List<LinqConcepts2> data2 = new List<LinqConcepts2>();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public static List<LinqConcepts2> getalldata()
        {
            data2.Add(new LinqConcepts2(1, "pen", 30));
            data2.Add(new LinqConcepts2(2, "ball", 45));

            return data2;

        }

        public LinqConcepts2(int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }


        public override string ToString()
        {
            return String.Format(Id + " " + Name + " " + Cost);
        }
    }



}
