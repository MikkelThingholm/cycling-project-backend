namespace App.EntityModels;

public class StageTeamStanding
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int RaceTeamParticipationId { get; set; }
    public RaceTeamParticipation RaceTeamParticipation { get; init; } = null!;

    public short Placement { get; set; }
    public int TimeMilliseconds { get; set; }
    public short TimePenaltySeconds { get; set; }
    public short BonusSeconds { get; set; }

}
