using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChaikaTechTestTask.Core.Points;

namespace ChaikaTechTestTask.Core.Context.DBConfiguration;


public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.ToTable("Points", "public");
        builder.HasKey(p => p.PointId);
        builder.Property(p => p.PointId).ValueGeneratedOnAdd();

        builder.Property(p => p.BeforeYesterdayPoints)
               .IsRequired();

        builder.Property(p => p.YesterdayPoints)
               .IsRequired();

        builder.Property(p => p.TotalPoints)
               .IsRequired();

        builder.HasOne(p => p.User)
            .WithOne(u => u.Point)
            .HasForeignKey<Point>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
