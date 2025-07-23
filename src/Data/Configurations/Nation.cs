using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class NationConfiguration : IEntityTypeConfiguration<Nation>
{
    public void Configure(EntityTypeBuilder<Nation> builder)
    {
        builder.ToTable("nations");

        builder.Property(n => n.Name).HasMaxLength(256);

        builder.HasIndex(n => n.Name).IsUnique();
    }
}
