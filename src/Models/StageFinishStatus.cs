
using System.ComponentModel.DataAnnotations;

namespace app.EntityModels;

public class StageFinishStatus
{
    [Key]
    public int Id { get; set;}

    [StringLength(50)]
    public string Name { get; set;} =null!;
}