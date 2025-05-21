namespace App.EntityModels;

public class RiderTeam
{

    public int Id { get; set; }

    public int RiderId { get; set; }
    public Rider Rider { get; set; } = null!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateOnly LeaveDate { get; set; }

}