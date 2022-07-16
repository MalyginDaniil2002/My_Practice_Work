using Microsoft.EntityFrameworkCore;
namespace My_PracticeWork.Models
{
    public class Users_Work : DbContext
    {
        public DbSet<Person> Users { get; set; } = null!;
        public Users_Work(DbContextOptions<Users_Work> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=My_Work;Trusted_Connection=True;");
        }
    }
}
