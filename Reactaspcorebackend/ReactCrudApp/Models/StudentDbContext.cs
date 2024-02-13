using Microsoft.EntityFrameworkCore;

namespace ReactCrudApp.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=lbs;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
