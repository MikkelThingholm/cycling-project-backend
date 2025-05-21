namespace App.EntityModels;

public class Mountain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<MountainClimb> MountainClimbs { get; set; } = [];
}