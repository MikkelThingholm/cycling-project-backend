namespace App.EntityModels;

public class Race
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;

    public int NationId { get; set; }
    public Nation Nation { get; init; } = null!;

    public ICollection<RaceEdition> RaceEditions { get; } = [];

}