using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class SprintResultConfiguration : IEntityTypeConfiguration<SprintResult>
{
    public void Configure(EntityTypeBuilder<SprintResult> builder)
    {
        builder.ToTable("sprint_results");

        builder.HasAlternateKey(x => new { x.SprintId, x.RaceRiderParticipationId });
    }
}
