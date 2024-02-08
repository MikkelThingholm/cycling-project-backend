using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class StageIndividualResult
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int StageId { get; set; }
    public Stage Stage { get; set;} = null!;

    public int RiderId { get; set; }
    public Rider Rider { get; set;} = null!;

    [Column(TypeName = "Int2")]
    public short Placement { get; set;}
    
    public int FinishTime { get; set;}

    [Column(TypeName = "Int2")]
    public short SprintPointObtained { get; set;}
    
    [Column(TypeName = "Int2")]
    public short ClimbingPointObtained { get; set;}
    
    [Column(TypeName = "Int2")]
    public short BonusPointObtained { get; set;}

}
