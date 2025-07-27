namespace App.EntityModels;

public class Rider
{

    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int NationId { get; set; }
    public Nation Nation { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public ICollection<RiderTeam> RiderTeams { get; } = null!;

}