using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class MountainConfiguration : IEntityTypeConfiguration<Mountain>
{
    public void Configure(EntityTypeBuilder<Mountain> builder)
    {
        builder.ToTable("mountains");

        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.Slug).HasMaxLength(256);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.Slug).IsUnique();

    }
}
