using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageRiderStandingConfiguration : IEntityTypeConfiguration<StageRiderStanding>
{
    public void Configure(EntityTypeBuilder<StageRiderStanding> builder)
    {
        builder.ToTable("stage_rider_standings");

        builder.HasIndex(x => new { x.StageId, x.RaceRiderParticipationId }).IsUnique();
    }
}
