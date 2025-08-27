namespace App.EntityModels;

public class StageRiderMountainResult
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; init; } = null!;

    public int Placement { get; set; }

    public int MountainPoints { get; set; }
    public short MountainPointsPenalty { get; set; }
}
