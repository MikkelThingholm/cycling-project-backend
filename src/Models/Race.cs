using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.EntityModels;

namespace App.EntityModels;

public class Race
{
    [Key]
    public int Id { get; set;}

    [StringLength(100)]
    public string Name { get; set;} = null!;

    public int NationId {get;set;}
    public Nation Nation {get;set;} = null!;

    public ICollection<RaceEdition> RaceEditions {get;} = [];

    public ICollection<OldRaceName> OldRaceNames {get;} = [];

}