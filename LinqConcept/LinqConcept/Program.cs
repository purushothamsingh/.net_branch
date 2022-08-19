using System;
using System.Linq;
using System.Collections.Generic;
namespace LinqConcept
{
    internal class Program
    {
        public static List<LinqConcepts2> data = LinqConcepts2.getalldata();
        static void Main()
        {

             
            foreach(LinqConcepts2 item in data)
            {
                Console.WriteLine(item.ToString());
                //ehllo
            }

            var filter = data.Where(d => d.Id == 2).Select(d => d);
            foreach(LinqConcepts2 item in filter)
            {
                Console.WriteLine(item.ToString());
            }
        }

        //static void Main()
        //{
        //    List<int> nums = new List<int>();

        //    nums.Add(40);
        //    nums.Add(30);
        //    nums.Add(60);
        //    nums.Add(89);
        //    nums.Add(12);

        //    var result = (from i in nums where i > 40 select i).ToList();
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Dictionary<int, string> fruits = new Dictionary<int, string>();

        //    fruits.Add(1, "apple");
        //    fruits.Add(2, "banana");
        //    fruits.Add(3, "carrot");

        //    var result2 = (from i in fruits where i.Value.StartsWith("a") select i).ToList();
        //    foreach (var item in result2)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    var res = fruits.Where(a => a.Value.StartsWith("c")).Select(a => a);
        //    foreach(var item in res)
        //    {
        //        Console.WriteLine(item.Value);
        //    }


        //}
    }
}