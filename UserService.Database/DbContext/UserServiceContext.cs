using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UserService.Database;

public class UserServiceContext : DbContext
{
    public UserServiceContext() { }
    public UserServiceContext(DbContextOptions<UserServiceContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"));
    }
}

