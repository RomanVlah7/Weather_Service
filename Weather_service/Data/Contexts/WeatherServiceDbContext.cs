using Microsoft.EntityFrameworkCore;
using Weather_service.Models;

namespace Weather_service.Data;

public class WeatherServiceDbContext: DbContext
{
    public WeatherServiceDbContext(DbContextOptions<WeatherServiceDbContext> options) 
        : base(options) { }
    
    public WeatherServiceDbContext() { }
    
    public DbSet<AppUser> AppUser { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=123vr456");
        }
    }
}