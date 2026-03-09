using LinkForge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkForge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public  AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<ShortLink> Links => Set<ShortLink>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortLink>()
            .HasIndex(x=> x.ShortCode)
            .IsUnique();
    }
    
    
}