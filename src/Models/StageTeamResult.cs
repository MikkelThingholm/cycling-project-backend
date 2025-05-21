namespace App.EntityModels;

public class StageTeamResult
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int RaceTeamParticipationId { get; set; }
    public RaceTeamParticipation RaceTeamParticipation { get; set; } = null!;

    public short Placement { get; set; }

    public int FinishTimeMilliseconds { get; set; }

}