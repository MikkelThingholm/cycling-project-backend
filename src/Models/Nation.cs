using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.EntityModels;

public class Nation
{
    [Key]
    public int Id { get; set;}

    [StringLength(100)]
    public string Name { get; set;} = null!;

    public bool StillExists { get; set;}
}