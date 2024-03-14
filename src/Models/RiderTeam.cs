using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace App.EntityModels;

public class RiderTeam
{
    [Key]
    public int Id {get;set;}

    public int RiderId { get;set; }
    public Rider Rider {get;set;} = null!;

    public int TeamId { get;set; }
    public Team Team {get;set;} = null!;

    public DateOnly Start {get;set;}

    public DateOnly End {get;set;}

}