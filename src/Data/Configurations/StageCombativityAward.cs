using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageCombativeAwardConfiguration : IEntityTypeConfiguration<StageCombativityAward>
{
    public void Configure(EntityTypeBuilder<StageCombativityAward> builder)
    {
        builder.ToTable("stage_combativity_awards");

        builder.HasIndex(x => new { x.StageId, x.RaceRiderParticipationId }).IsUnique();
    }
}
