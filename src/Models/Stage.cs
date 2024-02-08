using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.EntityModels;

public class Stage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int RaceEditionId { get; set; }
    public RaceEdition RaceEdition { get; set;} = null!;

    [Column(TypeName = "Int2")]
    public short StageNumber { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "NUMERIC(6,3)")]
    public float Distance { get; set; }

    [StringLength(50)]
    public string StageType { get; set;} = null!;
}
