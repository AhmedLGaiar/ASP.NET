using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class InstituteContextFactory : IDesignTimeDbContextFactory<InstituteContext>
{
    public InstituteContext CreateDbContext(string[] args)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Read connection string
        var connectionString = configuration.GetConnectionString("CS");

        // Configure DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<InstituteContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new InstituteContext(optionsBuilder.Options);
    }
}
