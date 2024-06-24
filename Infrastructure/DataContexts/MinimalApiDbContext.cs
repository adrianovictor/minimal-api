using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Entities;
using minimal_api.Infrastructure.Mappings;

namespace minimal_api.Infrastructure.DataContexts;

public class MinimalApiDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<Role> Roles{ get; set; }
    public DbSet<User> Users{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new UserMap());

        modelBuilder.Entity<Role>().HasData(
            new Role {
                Id = 1,
                Name = "Administrator",
                Description = "System administrator.",
                CreatedAt = DateTime.Now
            },
            new Role {
                Id = 2,
                Name = "Editor",
                Description = "Editor of the system informations.",
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User {
                Id = 1,
                Username = "admin",
                Email = "admin@admin.com",
                PasswordHash = "senha1234",
                RoleId = 1,
                CreatedAt = DateTime.Now
            },
            new User {
                Id = 2,
                Username = "editor",
                Email = "editor@editor.com",
                PasswordHash = "senha1234",
                RoleId = 2,
                CreatedAt = DateTime.Now
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection")?.ToString();

        if (!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        
    }
}
