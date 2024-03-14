using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace App.EntityModels;

public class Rider
{
    [Key]
    public int Id {get;set;}

    [MaxLength(100)]
    public string FirstName {get;set;} = null!;

    [MaxLength(100)]
    public string LastName {get;set;} = null!;

    public int NationId {get;set;}
    public Nation Nation {get;set;} = null!;
    
    public DateOnly BirthDate {get;set;}

    public ICollection<RiderTeam> RiderTeam { get;} = null!;

}