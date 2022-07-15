using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc;
namespace My_PracticeWork.Models
{
    public class Users_Work: DbContext
    {
        public DbSet<Person> Users { get; set; }
        public Users_Work(DbContextOptions<Users_Work> options): base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=My_Personal_Work;Trusted_Connection=True;");
        }
    }
}