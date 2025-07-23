using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageTeamResultConfiguration : IEntityTypeConfiguration<StageTeamResult>
{
    public void Configure(EntityTypeBuilder<StageTeamResult> builder)
    {
        builder.ToTable("stage_team_results");

        builder.HasIndex(x => new { x.StageId, x.RaceTeamParticipationId }).IsUnique();
    }
}
