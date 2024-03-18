using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private readonly string _dbPath;

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        //Courses Getter - Setter
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(course => course.Author)
                .WithMany();
        }
    }
}