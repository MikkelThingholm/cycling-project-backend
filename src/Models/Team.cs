using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "Int2")]
    public short Year { get; set; }

    public List<Rider> Riders { get; set; } = null!;

    public int MetaTeamId { get; set;}
    public MetaTeam MetaTeam { get; set; } = null!;
}