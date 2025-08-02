namespace App.EntityModels;

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;

    public short Year { get; set; }

    public ICollection<RiderTeam> RiderTeams { get; } = [];

    public int TeamOrganizationId { get; set; }
    public TeamOrganization TeamOrganization { get; } = null!;
}