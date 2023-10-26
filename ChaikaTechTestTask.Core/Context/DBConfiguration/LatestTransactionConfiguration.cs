using ChaikaTechTestTask.Core.LatestTransactions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Context.DBConfiguration;

public class LatestTransactionConfiguration : IEntityTypeConfiguration<LatestTransaction>
{
    public void Configure(EntityTypeBuilder<LatestTransaction> builder)
    {
        builder.ToTable("LatestTransactions", "public");
        builder.HasKey(lt => lt.TransactionId);
        builder.Property(lt => lt.TransactionId).ValueGeneratedOnAdd();

        builder.Property(lt => lt.Transaction)
               .IsRequired();

        builder.Property(lt => lt.Amount)
               .IsRequired();

        builder.Property(lt => lt.Balance)
               .IsRequired();

        builder.Property(lt => lt.TransactionName)
               .IsRequired();

        builder.Property(lt => lt.Description)
               .IsRequired();

        builder.Property(lt => lt.TransactionDate)
               .IsRequired();

        builder.Property(lt => lt.TransactionTime)
               .IsRequired();

        builder.Property(lt => lt.IsPending)
               .IsRequired();

        builder.Property(lt => lt.AuthorizedUser);

        builder.Property(lt => lt.IconURL);

        builder.HasOne(lt => lt.User)
               .WithMany()
               .HasForeignKey(lt => lt.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
