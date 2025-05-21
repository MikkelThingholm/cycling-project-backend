namespace App.EntityModels;

public class RaceTeamParticipation
{
    public int Id { get; set; }

    public int RaceEditionId { get; set; }
    public RaceEdition RaceEdition { get; init; } = null!;

    public int TeamId { get; set; }
    public Team Team { get; init; } = null!;

    public ICollection<RaceRiderParticipation> RaceRiderParticipations { get; set; } = [];
}