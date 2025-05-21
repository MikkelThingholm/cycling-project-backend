namespace App.EntityModels;

public class Sprint
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int DistanceFromStartMeters { get; set; }

    public bool IsFinish { get; set; }

    public ICollection<SprintResult> SprintResults { get; set; } = [];

}