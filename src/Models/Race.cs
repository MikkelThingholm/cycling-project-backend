using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.EntityModels;

public class Race
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}

    [MaxLength(100)]
    public string Name { get; set;} = null!;

    public int NationId {get;set;}
    public Nation Nation {get;set;} = null!;


}