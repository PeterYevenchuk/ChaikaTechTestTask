using ChaikaTechTestTask.Core.Context.DBConfiguration;
using ChaikaTechTestTask.Core.Context.Seeds;
using ChaikaTechTestTask.Core.LatestTransactions;
using ChaikaTechTestTask.Core.Points;
using ChaikaTechTestTask.Core.Users;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Context;

public class ChaikaTechDbContext : DbContext
{
    public ChaikaTechDbContext(DbContextOptions<ChaikaTechDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Point> Points { get; set; }

    public DbSet<LatestTransaction> LatestTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.ApplyConfiguration(new LatestTransactionConfiguration());
        modelBuilder.ApplyConfiguration(new PointConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        DataSeeder.SeedData(modelBuilder);
    }
}
