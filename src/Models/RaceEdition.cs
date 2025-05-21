namespace App.EntityModels;

public class RaceEdition
{

    public int Id { get; set; }

    public int RaceId { get; set; }
    public Race Race { get; set; } = null!;

    public string Name { get; set; } = null!;

    public short Year { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public ICollection<Stage> Stages { get; set; } = [];
}