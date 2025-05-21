using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class RaceRiderParticipationConfiguration : IEntityTypeConfiguration<RaceRiderParticipation>
{
    public void Configure(EntityTypeBuilder<RaceRiderParticipation> builder)
    {
        builder.ToTable("race_rider_participations");

        builder.HasAlternateKey(x => new { x.RaceTeamParticipationId, x.RiderId });
    }
}
