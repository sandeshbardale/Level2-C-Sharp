using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreCRUD
{
    // Student Model
    public class Student
    {
        public int Id { get; set; }         // Primary key
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }

    // DbContext class
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}