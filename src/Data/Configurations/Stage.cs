using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageConfiguration : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        builder.ToTable("stages");

        builder.Property(x => x.StartLocation).HasMaxLength(256);
        builder.Property(x => x.FinishLocation).HasMaxLength(256);

        builder.HasIndex(x => new { x.RaceEditionId, x.StageNumber }).IsUnique();
    }
}

