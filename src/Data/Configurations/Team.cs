using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("teams");

        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.Slug).HasMaxLength(256);

        builder.HasIndex(x => new { x.TeamOrganizationId, x.Year }).IsUnique();
        builder.HasIndex(x => x.Slug).IsUnique();
    }
}
