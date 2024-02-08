using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.EntityModels;

public class Race
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}

    [StringLength(50)]
    public string Name { get; set;} = null!;

    [StringLength(50)]
    public string Nation { get; set;} = null!;


}