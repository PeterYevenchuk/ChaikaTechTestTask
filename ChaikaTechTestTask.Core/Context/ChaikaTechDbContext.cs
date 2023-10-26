using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Context;

public class ChaikaTechDbContext : DbContext
{
    public ChaikaTechDbContext(DbContextOptions<ChaikaTechDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

}
