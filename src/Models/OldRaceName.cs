
using System.ComponentModel.DataAnnotations;
using App.EntityModels;

namespace app.EntityModels;

public class OldRaceName
{
    [Key]
    public int Key {get; set;}

    public int RaceId {get;set;}
    public Race Race {get;set;} = null!;

}