using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace MertKaymaz_HW4
{
    public class DatabaseDB : DbContext
    {
      
        string connectionString = @"Server=.\sqlexpress;Database=DatabaseDB;Trusted_Connection=True;";
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DatabaseDB() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
