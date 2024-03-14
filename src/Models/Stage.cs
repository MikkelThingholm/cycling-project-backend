using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class Stage
{
    [Key]
    public int Id { get; set; }

    public int RaceEditionId { get; set; }
    public RaceEdition RaceEdition { get; set;} = null!;

    [Column(TypeName = "Int2")]
    public short StageNumber { get; set; }

    public DateOnly Date { get; set; }

    public int Distance { get; set; }

    [StringLength(50)]
    public string StageType { get; set;} = null!;
}
