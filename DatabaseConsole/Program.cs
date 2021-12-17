using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace DatabaseConsole
{
    // Entity Framework ("EF")

    public class Student
    {
        public int StudentId { get; set; } //need get;set for the framework to find data
        public string Name { get; set; }
    } 

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class SchoolContext : DbContext
    {
       public DbSet<Student> Students { get; set; }
       public DbSet<Course> Courses { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
          optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=efconsole1;User Id=sa;Password=abc123;");   
       }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What student would you like to add?");
            //string entry = Console.ReadLine();

            using (var context = new SchoolContext())
            {
                //Student st = new Student() { StudentId = 2, Name = "Julio" };
                //context.Students.Update(st);
                //context.Students.Add(st);
                //context.SaveChanges();

                Student st2 = new Student() { Name = "Paul" };
                context.Students.Add(st2);

                Student st3 = new Student() { StudentId = 1, Name = "Mary" };
                context.Students.Update(st3);

                Student st4 = new Student() { StudentId = 5 };
                context.Students.Remove(st4);

                context.SaveChanges();
            }
            Console.WriteLine("All done!");
        }
    }
}


