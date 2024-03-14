using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class Team
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "Int2")]
    public short Year { get; set; }

    public ICollection<RiderTeam> RiderTeam { get;} = new List<RiderTeam>();

    public int MetaTeamId { get; set;}
    public MetaTeam MetaTeam { get; set; } = null!;
}