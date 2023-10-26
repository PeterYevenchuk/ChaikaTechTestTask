using ChaikaTechTestTask.Core.CardsBalances;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Context.DBConfiguration;

public class CardBalanceConfiguration : IEntityTypeConfiguration<CardBalance>
{
    public void Configure(EntityTypeBuilder<CardBalance> builder)
    {
        
    }
}
