namespace App.EntityModels;

public class StageNonFinish
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; init; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; init; } = null!;

    public NonFinishStatus Status { get; set; }
}

public enum NonFinishStatus
{
    DidNotStart = 1,
    DidNotFinish = 2,
    Disqualified = 3
}