using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageDidNotStartConfiguration : IEntityTypeConfiguration<StageNonFinish>
{
    public void Configure(EntityTypeBuilder<StageNonFinish> builder)
    {
        builder.ToTable("stage_non_finishes");

        builder.HasIndex(x => new { x.StageId, x.RaceRiderParticipationId }).IsUnique();
    }
}