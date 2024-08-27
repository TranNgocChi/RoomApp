using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RoomManagement.Database;

public class RoomContext : DbContext
{
    public RoomContext() { }
    public RoomContext(DbContextOptions<RoomContext> options) : base(options) { }

    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<RoomUser> RoomUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("PgSqlConnection"));
    }
}
    