using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR;

namespace App.EntityModels;

public class RaceEdition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int RaceId { get; set; }
    public Race Race { get; set;} = null!;

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [Column(TypeName = "Int2")]
    public short Year { get; set;}

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [StringLength(50)]
    public string RaceEditionType { get; set; } = null!;
}