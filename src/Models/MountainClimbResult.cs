namespace App.EntityModels;

public class MountainClimbResult
{
    public int Id { get; set; }

    public int MountainClimbId { get; set; }
    public MountainClimb MountainClimb { get; set; } = null!;

    public int RaceRiderParticipationId { get; set; }
    public RaceRiderParticipation RaceRiderParticipation { get; set; } = null!;

    public short Placement { get; set; }
    public short MountainPoints { get; set; }
    public short BonusSeconds { get; set; }

}