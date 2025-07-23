using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageResultStatusCodeConfiguration : IEntityTypeConfiguration<StageResultStatusCode>
{
    public void Configure(EntityTypeBuilder<StageResultStatusCode> builder)
    {
        builder.ToTable("stage_result_status_codes");

        builder.Property(x => x.Name).HasMaxLength(64);
        builder.Property(x => x.NameAbbreviation).HasMaxLength(64);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.NameAbbreviation).IsUnique();
    }
}