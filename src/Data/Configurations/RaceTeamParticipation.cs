using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class RaceTeamParticipationConfiguration : IEntityTypeConfiguration<RaceTeamParticipation>
{
    public void Configure(EntityTypeBuilder<RaceTeamParticipation> builder)
    {
        builder.ToTable("race_team_participations");

        builder.HasAlternateKey(x => new { x.RaceEditionId, x.TeamId });
    }
}
