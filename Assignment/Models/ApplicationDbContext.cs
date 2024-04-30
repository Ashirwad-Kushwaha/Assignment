using Microsoft.EntityFrameworkCore;

namespace Assignment.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<todolist> todolists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASHIRWAD\\SQLEXPRESS;Database=todolist;Integrated Security=true;TrustServerCertificate=true");
        }

    }

}
