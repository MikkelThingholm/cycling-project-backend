

namespace App.EntityModels;

public class Stage
{
    public int Id { get; set; }

    public int RaceEditionId { get; set; }
    public RaceEdition RaceEdition { get; set; } = null!;

    public short StageNumber { get; set; }

    public string StartLocation { get; set; } = null!;
    public string FinishLocation { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int DistanceMeters { get; set; }

    public int StageTypeId { get; set; }
    public StageType StageType { get; init; } = null!;


    public ICollection<StageTeamResult> StageTeamResults { get; set; } = [];
    public ICollection<StageRiderResult> StageRiderResults { get; set; } = [];
    public ICollection<Sprint> Sprints { get; set; } = [];
    public ICollection<MountainClimb> MountainClimbs { get; set; } = [];

}
