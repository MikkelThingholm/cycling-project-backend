using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.EntityModels;

public class StageTeamResult
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set;} = null!;

    public int TeamId { get; set; }
    public Team Team { get; set;} = null!;

    [Column(TypeName = "Int2")]
    public short Placement { get; set;}
    
    public int FinishTime { get; set;}

}