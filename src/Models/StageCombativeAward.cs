namespace App.EntityModels;

public class StageCombativityAward
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; init; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; init; } = null!;
}