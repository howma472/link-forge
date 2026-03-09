using Microsoft.EntityFrameworkCore;
using LinkForge.Domain.Entities;
using LinkForge.Infrastructure.Data.Configuration;

namespace LinkForge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ShortLink> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ShortLinkConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}