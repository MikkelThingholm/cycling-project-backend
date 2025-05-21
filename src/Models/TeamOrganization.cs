namespace App.EntityModels;

public class TeamOrganization
{
    public int Id { get; set; }

    public ICollection<Team> Teams { get; set; } = null!;

}
