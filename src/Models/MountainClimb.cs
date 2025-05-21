namespace App.EntityModels;

public class MountainClimb
{
    public int Id { get; set; }

    public int MountainId { get; set; }
    public Mountain Mountain { get; set; } = null!;

    public int StageId { get; set; }
    public Stage Stage { get; set; } = null!;

    public int ClimbLengthMeter { get; set; }

    public float AverageSlope { get; set; }

    public int DistanceFromStartMeters { get; set; }

    public bool IsFinish { get; set; }

}