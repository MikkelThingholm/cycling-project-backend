using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class RaceEditionConfiguration : IEntityTypeConfiguration<RaceEdition>
{
    public void Configure(EntityTypeBuilder<RaceEdition> builder)
    {
        builder.ToTable("race_editions");

        builder.Property(x => x.Name).HasMaxLength(256);

        builder.HasIndex(x => new { x.RaceId, x.Year }).IsUnique();
    }
}
