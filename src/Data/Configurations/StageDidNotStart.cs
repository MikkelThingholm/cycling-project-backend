using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageDidNotStartConfiguration : IEntityTypeConfiguration<StageDidNotStart>
{
    public void Configure(EntityTypeBuilder<StageDidNotStart> builder)
    {
        builder.ToTable("stage_did_not_starts");

        builder.HasAlternateKey(x => new { x.StageId, x.RaceRiderParticipationId });
    }
}