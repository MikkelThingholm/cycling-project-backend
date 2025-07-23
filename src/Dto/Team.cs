namespace App.Dto;

public record TeamResponse(
    int Id,
    string Name,
    short Year,
    ICollection<RiderTeamResponse> RiderTeams,
    TeamOrganizationResponse TeamOrganization
);

public record TeamSimpleResponse(
    int Id,
    string Name,
    short Year,
    ICollection<RiderTeamResponse> RiderTeams,
    int TeamOrganizationId
);

public record TeamCreateRequest(
    string Name,
    short Year,
    int TeamOrganizationId
);


public record TeamUpdateRequest(
    string Name,
    short Year,
    int TeamOrganizationId
);