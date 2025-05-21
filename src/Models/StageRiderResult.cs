namespace App.EntityModels;

public class StageRiderResult
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; init; } = null!;

    public short Placement { get; set; }

    public int FinishTimeMilliseconds { get; set; }

    public int StageFinishStatusCodeId { get; set; }
    public StageResultStatusCode StageResultStatusCode { get; set; } = null!;

}
