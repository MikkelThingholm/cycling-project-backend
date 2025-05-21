using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageTeamStandingConfiguration : IEntityTypeConfiguration<StageTeamStanding>
{
    public void Configure(EntityTypeBuilder<StageTeamStanding> builder)
    {
        builder.ToTable("stage_team_standings");

        builder.HasAlternateKey(x => new { x.StageId, x.RaceTeamParticipationId });
    }
}
