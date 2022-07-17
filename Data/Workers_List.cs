using Microsoft.EntityFrameworkCore;
using My_Practice_Work.Models;
namespace My_Practice_Work.Data
{
    public class Workers_List : DbContext
    {
        public DbSet<Worker> Workers { get; set; } = null!;
        public Workers_List(DbContextOptions<Workers_List> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocald;Database=My_Practice;Trusted_Connection=True;");
        }
    }
}