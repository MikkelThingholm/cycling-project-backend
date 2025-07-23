using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageCombativeAwardConfiguration : IEntityTypeConfiguration<StageCombativeAward>
{
    public void Configure(EntityTypeBuilder<StageCombativeAward> builder)
    {
        builder.ToTable("stage_combative_awards");

        builder.HasIndex(x => new { x.StageId, x.RaceRiderParticipationId }).IsUnique();
    }
}
