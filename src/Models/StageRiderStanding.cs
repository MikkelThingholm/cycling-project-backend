namespace App.EntityModels;

public class StageRiderStanding
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; init; } = null!;

    public int TimeMilliseconds { get; set; }
    public short TimePenaltySeconds { get; set; }
    public short BonusSeconds { get; set; }

    public short SprintPoints { get; set; }
    public short SprintPointsPenalty { get; set; }

    public short MountainPoints { get; set; }
    public short MountainPointsPenalty { get; set; }

}
