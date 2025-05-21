namespace App.EntityModels;

public class SprintResult
{
    public int Id { get; set; }

    public int SprintId { get; set; }
    public Sprint Sprint { get; set; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; set; } = null!;

    public short Placement { get; set; }
    public short Points { get; set; }
    public short BonusSeconds { get; set; }
}