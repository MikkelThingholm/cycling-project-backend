namespace App.EntityModels;

public class RaceRiderParticipation
{
    public int Id { get; set; }

    public int RaceTeamParticipationId { get; set; }
    public RaceTeamParticipation RaceTeamParticipation { get; init; } = null!;

    public int RiderId { get; set; }
    public Rider Rider { get; init; } = null!;
}