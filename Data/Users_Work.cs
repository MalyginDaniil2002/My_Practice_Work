using Microsoft.EntityFrameworkCore;
using My_Practice_Work.Models;
namespace My_Practice_Work.Data
{
    public class Users_Work : DbContext
    {
        public DbSet<Person> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public Users_Work(DbContextOptions<Users_Work> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=My_Practice_Work;Trusted_Connection=True;");
        }
    }
}
