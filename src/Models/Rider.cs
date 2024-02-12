using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace App.EntityModels;

public class Rider
{
    [Key]
    public int Id {get;set;}

    [StringLength(50)]
    public string FirstName {get;set;} = null!;

    [StringLength(50)]
    public string LastName {get;set;} = null!;

    [StringLength(50)]
    public string Nation {get;set;} = null!;
    
    public DateOnly BirthDate {get;set;}

}