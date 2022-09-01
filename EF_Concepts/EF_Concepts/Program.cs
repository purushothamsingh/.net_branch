using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Concepts;
using Microsoft.EntityFrameworkCore;

namespace EF_Concepts
{
    public class Program
    {
        public static ManagementContext db =  new ManagementContext();
       // public static Student std = new Student();
      
        public static void Main()
        {
            // InsertMultipleRecords();
          //  Showdetails();

            UpdateDetails();

        }

        private static void UpdateDetails()
        {
            using(var db = new ManagementContext())
            {
                Student s = new Student();
                Console.WriteLine("enter id to update");
                int id = Convert.ToInt32(Console.ReadLine());
                s= db.Students.Find(id);
                Console.WriteLine("enter name");
                s.S_Name = Console.ReadLine();
                s.S_age = Convert.ToInt32( Console.ReadLine());
                s.Sage_Phone = Convert.ToInt32( Console.ReadLine());
                db.Students.Update(s);
                db.SaveChanges();
            }
        }

        private static void Showdetails()
        {
            using(var db = new ManagementContext())
            {
                Student std = new Student();
                int id = Convert.ToInt32(Console.ReadLine());
                std = db.Students.Find(id);
                Console.WriteLine(std.S_Name);
                Console.WriteLine(std.S_age);
               
            }
        }

        private static void InsertMultipleRecords()
        {
            for (int i = 0; i < 2; i++)
            {
                Student std = new Student();
                using (var db = new ManagementContext())
                {
                    Console.WriteLine("Enter name age phone");
                    std.S_Name = Console.ReadLine();
                    std.S_age = int.Parse(Console.ReadLine());
                    std.Sage_Phone = int.Parse(Console.ReadLine());

                    db.Students.Add(std);
                    db.SaveChanges();
                }
            }
        }
    }
}
