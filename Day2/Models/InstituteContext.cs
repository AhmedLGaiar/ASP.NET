using Day2_Institute;
using Microsoft.EntityFrameworkCore;

namespace Day2.Models
{
    public class InstituteContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<crsResult> crsResult { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server=AHMEDELGAIAR;Database=Institute;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
