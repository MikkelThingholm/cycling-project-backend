using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.EntityModels;
using Microsoft.AspNetCore.SignalR;


namespace App.EntityModels;

public class StageRiderResult
{
    [Key]
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

    [Column(TypeName = "Int2")]
    public short TimePenalty { get; set;}

    public int StageFinishStatusId {get;set;}
    public StageFinishStatus StageFinishStatus {get;set;} = null!;

}
