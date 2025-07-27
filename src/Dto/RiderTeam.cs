namespace App.Dto;

public record RiderTeamResponse(
    int Id,
    DateOnly JoinDate,
    DateOnly LeaveDate,
    RiderSimpleResponse Rider,
    TeamSimpleResponse Team
);

public record RiderTeamSimpleResponse(
    int Id,
    DateOnly JoinDate,
    DateOnly LeaveDate,
    int RiderId,
    int TeamId
);


public record RiderTeamCreateRequest(
    DateOnly JoinDate,
    DateOnly LeaveDate,
    int RiderId,
    int TeamId
);


public record RiderTeamUpdateRequest(
    DateOnly JoinDate,
    DateOnly LeaveDate,
    int RiderId,
    int TeamId
);
