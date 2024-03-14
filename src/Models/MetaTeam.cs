using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class MetaTeam
{
    [Key]
    public int Id { get; set; }

    public ICollection<Team> Teams { get; set; } = null!;
    
}