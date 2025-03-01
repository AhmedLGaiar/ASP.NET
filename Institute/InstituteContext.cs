using Institute;
using Microsoft.EntityFrameworkCore;

public class InstituteContext : DbContext
{
    public DbSet<Course> Course { get; set; }
    public DbSet<crsResult> CrsResult { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Instructor> Instructor { get; set; }
    public DbSet<Trainee> Trainee { get; set; }

    public InstituteContext(DbContextOptions<InstituteContext> options) : base(options)
    {

    }
}
